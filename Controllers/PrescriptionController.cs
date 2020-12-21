using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Controllers
{
    [Route("api/perscriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionRepo _repositoryPrescription;
        private readonly IUserRepo _repositoryUser;
        private readonly IDrHelperRepo<Medicine> _repositoryMedicine;
        private readonly IMapper _mapper;

        public PrescriptionController(IPrescriptionRepo repositoryPrescription, IUserRepo repositoryUser, IDrHelperRepo<Medicine> repositoryMedicine, IMapper mapper)
        {
            _repositoryPrescription = repositoryPrescription;
            _repositoryUser = repositoryUser;
            _repositoryMedicine = repositoryMedicine;
            _mapper = mapper;
        }

        [HttpGet("user/{idUser}")]
        public ActionResult<IEnumerable<PrescriptionReadDTO>> GetUsersPrescriptions(int idUser)
        {
            var items = _repositoryPrescription.GetPrescriptions(idUser);
            List<Prescription> prescriptionsList = new List<Prescription>() ;
            foreach (UsersPrescriptions element in items)
            {
                prescriptionsList.Add(_repositoryPrescription.GetPrescriptionById(element.idPrescription));
            }
            if (prescriptionsList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<PrescriptionReadDTO>>(prescriptionsList));
        }

        [HttpGet("users/{idPrescription}")]
        public ActionResult<IEnumerable<UsersPrescriptionsReadDTO>> GetPrescriptionsUsersByPresciptionsId(int idPrescription)
        {
            var items = _repositoryPrescription.GetPrescriptionsUsersByPrescriptionsId(idPrescription);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UsersPrescriptionsReadDTO>>(items));
        }

        [HttpGet("medicine/{idPrescription}")]
        public ActionResult<IEnumerable<MedicineReadDTO>> GetPrescriptionsMedicine(int idPrescription)
        {
            var items = _repositoryPrescription.GetMedicine(idPrescription);
            List<Medicine> medicineList = new List<Medicine>();
            foreach (PrescriptionsMedicine element in items)
            {
                medicineList.Add(_repositoryMedicine.GetById(element.idMedicine));
            }
            if (medicineList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<MedicineReadDTO>>(medicineList));
        }

        [HttpGet("{id}", Name = "GetPrescription")]
        public ActionResult<PrescriptionReadDTO> GetPrescription(int id)
        {
            var item = _repositoryPrescription.GetPrescriptionById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<PrescriptionReadDTO>(item));
            }
            return NotFound();
        }

        [HttpGet("medicine/{idPrescription}/{idMedicine}", Name = "GetPrescriptionsMedicine")]
        public ActionResult<PrescriptionsMedicineReadDTO> GetPrescriptionsMedicine(int idPrescription, int idMedicine)
        {
            var item = _repositoryPrescription.GetPrescriptionsMedicineByIds(idPrescription, idMedicine);
            if (item != null)
            {
                return Ok(_mapper.Map<PrescriptionsMedicineReadDTO>(item));
            }
            return NotFound();
        }

        [HttpGet("user/{idUser}/{idPrescription}", Name = "GetUsersPrescription")]
        public ActionResult<UsersPrescriptionsReadDTO> GetUsersPrescription(int idUser, int idPrescription)
        {
            var item = _repositoryPrescription.GetPrescriptionsMedicineByIds(idUser, idPrescription);
            if (item != null)
            {
                return Ok(_mapper.Map<UsersPrescriptionsReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PrescriptionCreateDTO> CreatePrescription(PrescriptionCreateDTO dto)
        {
            DateTime temp;
            if (!DateTime.TryParse(dto.prescriptionDate, out temp))
            {
                return BadRequest("Wrong date format.");
            }

            var typeModel = _mapper.Map<Prescription>(dto);
            _repositoryPrescription.Create(typeModel);
            _repositoryPrescription.SaveChanges();

            var readDTO = _mapper.Map<PrescriptionReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetPrescription), new { id = readDTO.idPrescription }, readDTO);
        }

        [HttpPost]
        [Route("user")]
        public ActionResult<UsersPrescriptionsCreateDTO> ConnectUsers(UsersPrescriptionsCreateDTO dto)
        {
            var typeModel = _mapper.Map<UsersPrescriptions>(dto);
            _repositoryPrescription.ConnectUsers(typeModel);
            _repositoryPrescription.SaveChanges();

            var readDTO = _mapper.Map<UsersPrescriptionsReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetUsersPrescription), new { idUser = readDTO.idUser, idPrescription = readDTO.idPrescription }, readDTO);
        }

        [HttpPost]
        [Route("medicine")]
        public ActionResult<PrescriptionsMedicineCreateDTO> ConnectMedicine(PrescriptionsMedicineCreateDTO dto)
        {
            var prescriptionCheck = _repositoryPrescription.GetPrescriptionById(dto.idPrescription);
            if (prescriptionCheck == null)
            {
                return BadRequest("Non existent prescription.");
            }

            var medicineCheck = _repositoryMedicine.GetById(dto.idMedicine);
            if (medicineCheck == null)
            {
                return BadRequest("Non existent medicine.");
            }

            var prescriptionMedicineCheck = _repositoryPrescription.GetPrescriptionsMedicineByIds(dto.idPrescription, dto.idMedicine);
            if (prescriptionMedicineCheck != null)
            {
                return BadRequest("Existent in database.");
            }
            var typeModel = _mapper.Map<PrescriptionsMedicine>(dto);
            _repositoryPrescription.ConnectMedicine(typeModel);
            _repositoryPrescription.SaveChanges();

            var readDTO = _mapper.Map<PrescriptionsMedicineReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetPrescriptionsMedicine), new { idPrescription = readDTO.idPrescription, idMedicine = readDTO.idMedicine }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePrescription(int id, PrescriptionCreateDTO dto)
        {
            var modelFromRepo = _repositoryPrescription.GetPrescriptionById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            DateTime temp;
            if (!DateTime.TryParse(dto.prescriptionDate, out temp))
            {
                return BadRequest("Wrong date format.");
            }

            _mapper.Map(dto, modelFromRepo);

            _repositoryPrescription.Update();

            _repositoryPrescription.SaveChanges();

            return NoContent();
        }

        [HttpDelete("medicine/{idPrescription}/{idMedicine}")]
        public ActionResult DeletePrescriptionMedicine(int idPrescription, int idMedicine)
        {
            var modelFromRepo = _repositoryPrescription.GetPrescriptionsMedicineByIds(idPrescription, idMedicine);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _repositoryPrescription.DeleteMedicineConnections(modelFromRepo);
            _repositoryPrescription.SaveChanges();

            return NoContent();
        }

        [HttpDelete("user/{idUser}/{idPrescription}")]
        public ActionResult DeleteUsersPrescription(int idUser, int idPrescription)
        {
            var modelFromRepo = _repositoryPrescription.GetUsersPrescriptionByIds(idUser, idPrescription);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            _repositoryPrescription.DeleteUsersConnections(modelFromRepo);
            _repositoryPrescription.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePrescription(int id)
        {
            var modelFromRepo = _repositoryPrescription.GetPrescriptionById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _repositoryPrescription.DeletePrescription(modelFromRepo);
            _repositoryPrescription.SaveChanges();

            return NoContent();
        }
    }
}
