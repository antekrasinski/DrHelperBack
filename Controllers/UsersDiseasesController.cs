using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DrHelperBack.Controllers
{

    [Route("api/usersDiseases")]
    [ApiController]
    public class UsersDiseasesController : ControllerBase
    {
        private readonly IUsersDiseases _repositoryUsersDiseases;
        private readonly IDrHelperRepo<User> _repositoryUser;
        private readonly IDrHelperRepo<Disease> _repositoryDisease;
        private readonly IMapper _mapper;

        public UsersDiseasesController(IUsersDiseases repositoryUsersDiseases, IDrHelperRepo<User> repositoryUser, IDrHelperRepo<Disease> repositoryDisease, IMapper mapper)
        {
            _repositoryUsersDiseases = repositoryUsersDiseases;
            _repositoryUser = repositoryUser;
            _repositoryDisease = repositoryDisease;

            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UsersDiseasesReadDTO>> GetUsersDiseases(int id)
        {
            var items = _repositoryUsersDiseases.GetUsersDiseases(id);

            return Ok(_mapper.Map<IEnumerable<UsersDiseasesReadDTO>>(items));
        }

        [HttpGet("{idUser}/{idDisease}", Name = "GetByIds")]
        public ActionResult<UsersDiseasesReadDTO> GetByIds(int idUser, int idDisease)
        {
            var item = _repositoryUsersDiseases.GetByIds(idUser, idDisease);
            if (item != null)
            {
                return Ok(_mapper.Map<UsersDiseasesReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UsersDiseasesCreateDTO> CreateConnection(UsersDiseasesCreateDTO dto)
        {
            var userCheck = _repositoryUser.GetById(dto.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user.");
            }

            var diseaseCheck = _repositoryDisease.GetById(dto.idDisease);
            if (diseaseCheck == null)
            {
                return BadRequest("Non existent disease.");
            }

            var usersDiseasesCheck = _repositoryUsersDiseases.GetByIds(dto.idUser, dto.idDisease);
            if (usersDiseasesCheck != null)
            {
                return BadRequest("Existent in database.");
            }

            DateTime temp;
            if (!DateTime.TryParse(dto.occurrenceDate, out temp))
            {
                return BadRequest("Wrong date format.");
            }

            var typeModel = _mapper.Map<UsersDiseases>(dto);
            _repositoryUsersDiseases.Create(typeModel);
            _repositoryUsersDiseases.SaveChanges();

            var readDTO = _mapper.Map<UsersDiseasesReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetByIds), new { idUser = readDTO.idUser, idDisease = readDTO.idDisease }, readDTO);
        }

        [HttpPut("{idUser}/{idDisease}")]
        public ActionResult UpdateMedicine(int idUser, int idDisease, UsersDiseasesCreateDTO dto)
        {
            var modelFromRepo = _repositoryUsersDiseases.GetByIds(idUser, idDisease);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var userCheck = _repositoryUser.GetById(dto.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user.");
            }

            var diseaseCheck = _repositoryDisease.GetById(dto.idDisease);
            if (diseaseCheck == null)
            {
                return BadRequest("Non existent disease.");
            }

            DateTime temp;
            if (!DateTime.TryParse(dto.occurrenceDate, out temp))
            {
                return BadRequest("Wrong date format.");
            }

            _mapper.Map(dto, modelFromRepo);

            _repositoryUsersDiseases.Update(modelFromRepo);

            _repositoryUsersDiseases.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{idUser}/{idDisease}")]
        public ActionResult DeleteConnection(int idUser, int idDisease)
        {
            var modelFromRepo = _repositoryUsersDiseases.GetByIds(idUser, idDisease);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _repositoryUsersDiseases.Delete(modelFromRepo);
            _repositoryUsersDiseases.SaveChanges();

            return NoContent();
        }
    }

}
