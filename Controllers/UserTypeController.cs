using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DrHelperBack.Controllers
{
    [Route("api/userTypes")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IDrHelperRepo<UserType> _repository;
        private readonly IMapper _mapper;

        public UserTypeController(IDrHelperRepo<UserType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserTypeReadDTO>> GetUserTypes()
        {
            var items = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserTypeReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetUserType")]
        public ActionResult<UserTypeReadDTO> GetUserType(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<UserTypeReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserTypeCreateDTO> CreateUserType(UserTypeCreateDTO dto)
        {
            var typeModel = _mapper.Map<UserType>(dto);
            _repository.Create(typeModel);
            _repository.SaveChanges();

            var readDTO = _mapper.Map<UserTypeReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetUserType), new { id = readDTO.idUserType }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUserType(int id, UserTypeCreateDTO dto)
        {
            var modelFromRepo = _repository.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, modelFromRepo);

            _repository.Update(modelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUserTypeUpdate(int id, JsonPatchDocument<UserTypeCreateDTO> patchDoc)
        {

            var modelFromRepo = _repository.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var typeToPatch = _mapper.Map<UserTypeCreateDTO>(modelFromRepo);
            patchDoc.ApplyTo(typeToPatch, ModelState);
            if (!TryValidateModel(typeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(typeToPatch, modelFromRepo);

            _repository.Update(modelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserType(int id)
        {
            var modelFromRepo = _repository.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(modelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
