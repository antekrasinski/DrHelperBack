using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.DTOs;
using DrHelperBack.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrHelperBack.Controllers
{
    [Route("api/timeblocks")]
    [ApiController]
    public class TimeblockController : ControllerBase
    {
        private readonly IUserRepo _repositoryUser;
        private readonly ITimeblockRepo _repositoryTimeblock;
        private readonly IMapper _mapper;

        public TimeblockController(IUserRepo repositoryUser, ITimeblockRepo repositoryTimeblock, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _repositoryTimeblock = repositoryTimeblock;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TimeblockReadDTO>> GetTimeblocks()
        {
            var items = _repositoryTimeblock.GetAll();

            return Ok(_mapper.Map<IEnumerable<TimeblockReadDTO>>(items));
        }

        [HttpGet("{id}", Name = "GetTimeblock")]
        public ActionResult<TimeblockReadDTO> GetTimeblock(int id)
        {
            var item = _repositoryTimeblock.GetById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<TimeblockReadDTO>(item));
            }
            return NotFound();
        }

        [HttpGet("user/{id}")]
        public ActionResult<TimeblockReadDTO> GetUsersTimeblocks(int id)
        {
            var items = _repositoryTimeblock.GetUsersTimeblocks(id);
            return Ok(_mapper.Map<IEnumerable<TimeblockReadDTO>>(items));
        }

        [HttpGet("appointment/{id}")]
        public ActionResult<TimeblockReadDTO> GetAppointmentTimeblocks(int id)
        {
            var items = _repositoryTimeblock.GetTimeblocksByAppointmentId(id);
            return Ok(_mapper.Map<IEnumerable<TimeblockReadDTO>>(items));
        }

        [HttpPost]
        public ActionResult<TimeblockCreateDTO> CreateTimeblock(TimeblockCreateDTO dto)
        {
            var userCheck = _repositoryUser.GetById(dto.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            DateTime temp;
            if (!DateTime.TryParse(dto.startTime, out temp))
            {
                return BadRequest("Wrong startTime date format.");
            }
            if (!DateTime.TryParse(dto.endTime, out temp))
            {
                return BadRequest("Wrong endTime date format.");
            }

            var typeModel = _mapper.Map<Timeblock>(dto);
            if(typeModel.startTime > typeModel.endTime)
            {
                temp = typeModel.endTime;
                typeModel.endTime = typeModel.startTime;
                typeModel.startTime = temp;
            }
            _repositoryTimeblock.Create(typeModel);
            _repositoryTimeblock.SaveChanges();

            var readDTO = _mapper.Map<TimeblockReadDTO>(typeModel);

            return CreatedAtRoute(nameof(GetTimeblock), new { id = readDTO.idTimeblock }, readDTO);
        }

        [HttpPost]
        [Route("shift")]
        public ActionResult<IEnumerable<TimeblockCreateDTO>> CreateShift(ShiftDTO dto)
        {
            var userCheck = _repositoryUser.GetById(dto.idUser);
            if (userCheck == null)
            {
                return BadRequest("Non existent user type.");
            }

            if (!DateTime.TryParse(dto.shiftStart, out DateTime start))
            {
                return BadRequest("Wrong shiftStart date format.");
            }
            if (!DateTime.TryParse(dto.shiftEnd, out DateTime end))
            {
                return BadRequest("Wrong shiftEnd date format.");
            }
            if (!TimeSpan.TryParse(dto.appointmentSpan, out TimeSpan span))
            {
                return BadRequest("Wrong appointmentSpan date format.");
            }

            DateTime temp = start;
            if (start > end)
            {     
                temp = end;
                end = start;
                start = temp;
            }

            while((temp+span) <= end)
            {
                _repositoryTimeblock.Create(new Timeblock { startTime = temp, endTime = temp+span, avaliable = true, idUser=dto.idUser, idAppointment=0 });
                temp += span;
            }
            _repositoryTimeblock.SaveChanges();
            var items = _repositoryTimeblock.GetUsersTimeblocks(dto.idUser).Where(t => t.startTime >= start && t.endTime <= end);
            return Ok(_mapper.Map<IEnumerable<TimeblockReadDTO>>(items));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTimeblock(int id, TimeblockCreateDTO dto)
        {
            var modelFromRepo = _repositoryTimeblock.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            var userTypeCheck = _repositoryUser.GetById(dto.idUser);
            if (userTypeCheck == null)
            {
                return BadRequest("Non existent user.");
            }

            _mapper.Map(dto, modelFromRepo);

            _repositoryTimeblock.Update(modelFromRepo);

            _repositoryTimeblock.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTimeblock(int id)
        {
            var modelFromRepo = _repositoryTimeblock.GetById(id);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _repositoryTimeblock.Delete(modelFromRepo);
            _repositoryTimeblock.SaveChanges();

            return NoContent();
        }
    }
}
