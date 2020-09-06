using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeServer.Controllers
{
    [Route("api/programs")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ProgramsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAllPrograms()
        {
            try
            {
                var Programs = _repository.Programs.GetAllPrograms();
                _logger.LogInfo($"Returned all Programs from database.");
                 var ProgramsResult = _mapper.Map<IEnumerable<ProgramDTO>>(Programs);
                return Ok(ProgramsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPrograms action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
        [HttpGet("{id}", Name = "ProgramById")]
        public IActionResult GetProgramById(Guid Id)
        {
            try
            {
                var Program = _repository.Programs.GetProgramById(Id);
                if (Program == null)
                {
                    _logger.LogError($"Program with id: {Id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Program with id: {Id}");
                    var ProgramResult = _mapper.Map<ProgramDTO>(Program);
                    return Ok(ProgramResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramsById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost]
        public IActionResult CreateProgram([FromBody] ProgramForCreationDto Program)
        {
            try
            {
                if (Program == null)
                {
                    _logger.LogError("Program object sent from client is null.");
                    return BadRequest("Program object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Program object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var ProgramEntity = _mapper.Map<Programs>(Program);
                _repository.Programs.CreateProgram(ProgramEntity);
                _repository.Save();
                var createdProgram = _mapper.Map<ProgramDTO>(ProgramEntity);
                return CreatedAtRoute("ProgramById", new { id = createdProgram.Id }, createdProgram);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgram action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] ProgramForUpdateDto Program)
        {
            try
            {
                if (Program == null)
                {
                    _logger.LogError("Program object sent from client is null.");
                    return BadRequest("Program object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Program object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var ProgramEntity = _repository.Programs.GetProgramById(id);
                if (ProgramEntity == null)
                {
                    _logger.LogError($"Program with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(Program, ProgramEntity);
                _repository.Programs.UpdateProgram(ProgramEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
