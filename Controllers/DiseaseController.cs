using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DrHelperBack.Controllers
{
    [Route("api/diseases")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDrHelperRepo<Disease> _repository;
        private readonly IMapper _mapper;

        public DiseaseController(IDrHelperRepo<Disease> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiseaseReadDTO>> GetDiseases()
        {
            var items = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<DiseaseReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetDisease")]
        public ActionResult<DiseaseReadDTO> GetDisease(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<DiseaseReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<DiseaseCreateDTO> CreateDisease(DiseaseCreateDTO dto)
        {
            var typeModel = _mapper.Map<Disease>(dto);
            _repository.Create(typeModel);
            _repository.SaveChanges();

            var readDTO = _mapper.Map<DiseaseReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetDisease), new { id = readDTO.idDisease }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDisease(int id, DiseaseCreateDTO dto)
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
        public ActionResult PartialDiseaseUpdate(int id, JsonPatchDocument<DiseaseCreateDTO> patchDoc)
        {

            var modelFromRepo = _repository.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var typeToPatch = _mapper.Map<DiseaseCreateDTO>(modelFromRepo);
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
        public ActionResult DeleteDisease(int id)
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

        [HttpDelete]
        public ActionResult DeleteAllDiseases()
        {
            _repository.DeleteAll();
            _repository.SaveChanges();
            return NoContent();
        }
    }
}

