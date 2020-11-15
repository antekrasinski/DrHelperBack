using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DrHelperBack.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IDrHelperRepo<Medicine> _repository;
        private readonly IMapper _mapper;

        public MedicineController(IDrHelperRepo<Medicine> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MedicineReadDTO>> GetMedicine()
        {
            var items = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<MedicineReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetMedicineById")]
        public ActionResult<DiseaseReadDTO> GetMedicineById(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<MedicineReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MedicineCreateDTO> CreateMedicine(MedicineCreateDTO dto)
        {
            var typeModel = _mapper.Map<Medicine>(dto);
            _repository.Create(typeModel);
            _repository.SaveChanges();

            var readDTO = _mapper.Map<MedicineReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetMedicineById), new { id = readDTO.id_medicine }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMedicine(int id, MedicineCreateDTO dto)
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
        public ActionResult PartialMedicineUpdate(int id, JsonPatchDocument<MedicineCreateDTO> patchDoc)
        {

            var modelFromRepo = _repository.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var typeToPatch = _mapper.Map<MedicineCreateDTO>(modelFromRepo);
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
        public ActionResult DeleteMedicine(int id)
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
