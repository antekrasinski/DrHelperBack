using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DrHelperBack.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repositoryUser;
        private readonly IDrHelperRepo<UserType> _repositoryUserType;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserController(IUserRepo repositoryUser, IDrHelperRepo<UserType> repositoryUserType, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repositoryUser = repositoryUser;
            _repositoryUserType = repositoryUserType;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var items = _repositoryUser.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserReadDTO> GetUser(int id)
        {
            var item = _repositoryUser.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<UserReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(SignInDTO dto)
        {
            var user = _repositoryUser.Authenticate(dto.username, dto.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.idUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                idUser = user.idUser,
                username = user.username,
                name = user.name,
                surname = user.surname,
                description = user.description,
                idUserType = user.idUserType,
                token = tokenString
            });
        }


        [HttpPost]
        public ActionResult<UserCreateDTO> CreateUser(UserCreateDTO dto)
        {
            var typeModel = _mapper.Map<User>(dto);
            var userTypeCheck = _repositoryUserType.GetById(dto.idUserType);
            if (userTypeCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            try
            {
                _repositoryUser.Create(typeModel, dto.password);
            }
            catch(ApplicationException e)
            {
                return BadRequest(e);
            }
            _repositoryUser.SaveChanges();

            var readDTO = _mapper.Map<UserReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetUser), new { id = readDTO.idUser }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserCreateDTO dto)
        {
            var modelFromRepo = _repositoryUser.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            var userTypeCheck = _repositoryUserType.GetById(dto.idUserType);
            if (userTypeCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            _mapper.Map(dto, modelFromRepo);
            try
            {
                _repositoryUser.Update(modelFromRepo, dto.password);
            }
            catch(ApplicationException e)
            {
                return BadRequest(e);
            }
            _repositoryUser.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserCreateDTO> patchDoc)
        {

            var modelFromRepo = _repositoryUser.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var typeToPatch = _mapper.Map<UserCreateDTO>(modelFromRepo);
            patchDoc.ApplyTo(typeToPatch, ModelState);

            var userTypeCheck = _repositoryUserType.GetById(typeToPatch.idUserType);
            if (userTypeCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            if (!TryValidateModel(typeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(typeToPatch, modelFromRepo);

            //_repositoryUser.Update(modelFromRepo, modelFromRepo.password);

            _repositoryUser.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var modelFromRepo = _repositoryUser.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _repositoryUser.Delete(modelFromRepo);
            _repositoryUser.SaveChanges();

            return NoContent();
        }
    }
}

