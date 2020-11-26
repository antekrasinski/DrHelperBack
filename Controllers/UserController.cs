using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DrHelperBack.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IDrHelperRepo<User> _repositoryUser;
        private readonly IDrHelperRepo<UserType> _repositoryUserType;
        private readonly IMapper _mapper;

        public UserController(IDrHelperRepo<User> repositoryUser, IDrHelperRepo<UserType> repositoryUserType, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _repositoryUserType = repositoryUserType;
            _mapper = mapper;
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

        [HttpPost]
        public ActionResult<UserCreateDTO> CreateUser(UserCreateDTO dto)
        {
            var typeModel = _mapper.Map<User>(dto);
            var userTypeCheck = _repositoryUserType.GetById(dto.idUserType);
            if (userTypeCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            _repositoryUser.Create(typeModel);
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

            _repositoryUser.Update(modelFromRepo);

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

            _repositoryUser.Update(modelFromRepo);

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

