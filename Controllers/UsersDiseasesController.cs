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
        private readonly IUserRepo _repositoryUser;
        private readonly IDrHelperRepo<Disease> _repositoryDisease;
        private readonly IMapper _mapper;

        public UsersDiseasesController(IUsersDiseases repositoryUsersDiseases, IUserRepo repositoryUser, IDrHelperRepo<Disease> repositoryDisease, IMapper mapper)
        {
            _repositoryUsersDiseases = repositoryUsersDiseases;
            _repositoryUser = repositoryUser;
            _repositoryDisease = repositoryDisease;

            _mapper = mapper;
        }

        [HttpGet("user/{id}")]
        public ActionResult<IEnumerable<UsersDiseasesReadDTO>> GetUsersDiseases(int id)
        {
            var items = _repositoryUsersDiseases.GetUsersDiseases(id);

            return Ok(_mapper.Map<IEnumerable<UsersDiseasesReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetUsersDiseasesById")]
        public ActionResult<UsersDiseasesReadDTO> GetUsersDiseasesById(int idUsersDiseases)
        {
            var item = _repositoryUsersDiseases.GetById(idUsersDiseases);
            if (item != null)
            {
                return Ok(_mapper.Map<UsersDiseasesReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UsersDiseasesCreateDTO> CreateConnection(UsersDiseasesCreateDTO dto)
        {
            var typeModel = _mapper.Map<UsersDiseases>(dto);
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

            _repositoryUsersDiseases.Create(typeModel);
            _repositoryUsersDiseases.SaveChanges();

            var readDTO = _mapper.Map<UsersDiseasesReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetUsersDiseasesById), new { id = readDTO.idUsersDiseases }, readDTO);
        }

        [HttpPut("{idUsersDiseases}")]
        public ActionResult UpdateMedicine(int idUsersDiseases, UsersDiseasesCreateDTO dto)
        {
            var modelFromRepo = _repositoryUsersDiseases.GetById(idUsersDiseases);
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

        [HttpDelete("{idUsersDiseases}")]
        public ActionResult DeleteConnection(int idUsersDiseases)
        {
            var modelFromRepo = _repositoryUsersDiseases.GetById(idUsersDiseases);
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
