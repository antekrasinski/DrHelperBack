using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrHelperBack.Controllers
{
    [Route("api/perscriptions")]
    [ApiController]
    public class PerscriptionController : ControllerBase
    {
        private readonly IPerscriptionRepo _repositoryPerscription;
        private readonly IDrHelperRepo<User> _repositoryUser;
        private readonly IDrHelperRepo<Medicine> _repositoryMedicine;
        private readonly IMapper _mapper;

        public PerscriptionController(IPerscriptionRepo repositoryPerscription, IDrHelperRepo<User> repositoryUser, IDrHelperRepo<Medicine> repositoryMedicine, IMapper mapper)
        {
            _repositoryPerscription = repositoryPerscription;
            _repositoryUser = repositoryUser;
            _repositoryMedicine = repositoryMedicine;
            _mapper = mapper;
        }

        [HttpGet("{idUser}")]
        public ActionResult<IEnumerable<PerscriptionReadDTO>> GetUsersPerscriptions(int idUser)
        {
            var items = _repositoryPerscription.GetPerscriptions(idUser);
            List<Perscription> perscriptionsList = null;
            foreach (UsersPerscriptions element in items)
            {
                perscriptionsList.Add(_repositoryPerscription.GetPerscpitionById(element.idPerscription));
            }
            if (perscriptionsList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<PerscriptionReadDTO>>(perscriptionsList));
        }

        [HttpGet("details/{idPerscription}")]
        public ActionResult<IEnumerable<MedicineReadDTO>> GetPerscriptionDetails(int idPerscription)
        {
            var items = _repositoryPerscription.GetMedicine(idPerscription);
            List<Medicine> medicineList = null;
            foreach (PerscriptionsMedicine element in items)
            {
                medicineList.Add(_repositoryMedicine.GetById(element.idMedicine));
            }
            if (medicineList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<MedicineReadDTO>>(medicineList));
        }

        [HttpGet("{id}", Name = "GetPerscription")]
        public ActionResult<PerscriptionReadDTO> GetPerscription(int id)
        {
            var item = _repositoryPerscription.GetPerscpitionById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<PerscriptionReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PerscriptionCreateDTO> CreatePerscription(PerscriptionCreateDTO dto)
        {
            DateTime temp;
            if (!DateTime.TryParse(dto.perscriptionDate, out temp))
            {
                return BadRequest("Wrong date format.");
            }

            var typeModel = _mapper.Map<Perscription>(dto);
            _repositoryPerscription.Create(typeModel);
            _repositoryPerscription.SaveChanges();

            var readDTO = _mapper.Map<PerscriptionReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetPerscription), new { id = readDTO.idPerscription }, readDTO);
        }

        [HttpPost]
        [Route("connect")]
        public ActionResult<UsersPerscriptionsCreateDTO> ConnectUsers(UsersPerscriptionsCreateDTO dto)
        {
            var typeModel = _mapper.Map<UsersPerscriptions>(dto);
            _repositoryPerscription.ConnectUsers(typeModel);
            _repositoryPerscription.SaveChanges();

            var readDTO = _mapper.Map<UsersPerscriptionsReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetPerscription), new { id = readDTO.idPerscription }, readDTO);
        }

        [HttpPost]
        [Route("medicine")]
        public ActionResult<PerscriptionsMedicineCreateDTO> ConnectMedicine(PerscriptionsMedicineCreateDTO dto)
        {
            var typeModel = _mapper.Map<PerscriptionsMedicine>(dto);
            _repositoryPerscription.ConnectMedicine(typeModel);
            _repositoryPerscription.SaveChanges();

            var readDTO = _mapper.Map<PerscriptionReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetPerscription), new { id = readDTO.idPerscription }, readDTO);
        }

        //TO DO
        /*[HttpPut("{id}")]
        public ActionResult UpdateTimeblock(int id, TimeblockCreateDTO dto)
        {
            var modelFromRepo = _repositoryTimeblock.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            var userCheck = _repositoryUser.GetById(dto.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            _mapper.Map(dto, modelFromRepo);

            _repositoryTimeblock.Update(modelFromRepo);

            _repositoryTimeblock.SaveChanges();

            return NoContent();
        }

        //TO DO
        [HttpPatch("{id}")]
        public ActionResult PartialTimeblockUpdate(int id, JsonPatchDocument<TimeblockCreateDTO> patchDoc)
        {

            var modelFromRepo = _repositoryTimeblock.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }

            var typeToPatch = _mapper.Map<TimeblockCreateDTO>(modelFromRepo);
            patchDoc.ApplyTo(typeToPatch, ModelState);

            var userCheck = _repositoryUser.GetById(typeToPatch.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            if (!TryValidateModel(typeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(typeToPatch, modelFromRepo);

            _repositoryTimeblock.Update(modelFromRepo);

            _repositoryTimeblock.SaveChanges();

            return NoContent();
        }*/

        [HttpDelete("{id}")]
        public ActionResult DeletePerscription(int id)
        {
            var modelFromRepo = _repositoryPerscription.GetPerscpitionById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            
            var medicineList = _repositoryPerscription.GetMedicine(id);
            foreach(PerscriptionsMedicine element in medicineList)
            {
                _repositoryPerscription.DeleteConnectionMedicine(element);
            }

            var userList = _repositoryPerscription.GetUsersConnections().Where(p=>p.idPerscription == id);
            foreach (UsersPerscriptions element in userList)
            {
                _repositoryPerscription.DeleteUsersConnections(element);
            }

            _repositoryPerscription.DeletePerscription(modelFromRepo);
            _repositoryPerscription.SaveChanges();

            return NoContent();
        }
    }
}
