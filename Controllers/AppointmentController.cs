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
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _repositoryAppointment;
        private readonly ITimeblockRepo _repositoryTimeblock;
        private readonly IUserRepo _repositoryUser;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepo repositoryAppointment, ITimeblockRepo repositoryTimeblock, IUserRepo repositoryUser, IMapper mapper)
        {
            _repositoryAppointment = repositoryAppointment;
            _repositoryTimeblock = repositoryTimeblock;
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentReadDTO>> GetAppointments()
        {
            var items = _repositoryAppointment.GetAll();

            return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public ActionResult<AppointmentReadDTO> GetAppointment(int id)
        {
            var item = _repositoryAppointment.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<AppointmentReadDTO>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AppointmentCreateDTO> CreateAppointment(AppointmentCreateDTO dto)
        {
            var typeModel = _mapper.Map<Appointment>(dto);
            _repositoryAppointment.Create(typeModel);
            _repositoryAppointment.SaveChanges();

            var readDTO = _mapper.Map<AppointmentReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetAppointment), new { id = readDTO.idAppointment }, readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAppointment(int id, AppointmentCreateDTO dto)
        {
            var modelFromRepo = _repositoryAppointment.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            
            _mapper.Map(dto, modelFromRepo);

            _repositoryAppointment.Update(modelFromRepo);

            _repositoryAppointment.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var modelFromRepo = _repositoryAppointment.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _repositoryAppointment.Delete(modelFromRepo);
            _repositoryAppointment.SaveChanges();

            return NoContent();
        }

    }
}
