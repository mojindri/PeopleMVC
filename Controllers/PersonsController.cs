using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment_server_side.Repository;
using assessment_server_side.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using assessment_server_side.Utils;
using assessment_server_side.Controllers.Serializer;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using assessment_server_side.Exceptions;
using System.Diagnostics.Eventing.Reader;
using AutoMapper;
using assessment_server_side.Controllers.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assessment_server_side.Controllers
{
    [Route("persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IFavouriteColorRepository _favColorRepo;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IMapper _imapper;

        private PersonJsonConverter ConvertJson(Person person) => new PersonJsonConverter(person);
        private IEnumerable<PersonJsonConverter> ConvertJson(IEnumerable<Person> people)
            => (from p in people
                select ConvertJson(p)).ToList();

        public PersonsController(IFavouriteColorRepository fav, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this._favColorRepo = fav;
            this._loggerFactory = loggerFactory;
            this._imapper = mapper;
     
        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            try
            {
                
                var res = this._favColorRepo.GetPeople();
                return Ok(ConvertJson(res));

            }
            catch (PersonNotExistException )
            {
                var logger = _loggerFactory.CreateLogger("nodata");
                logger.LogWarning("Nothing returned to client,since no data was available");
                return StatusCode(StatusCodes.Status404NotFound, "No Person Found.");
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger("Unhandled Exception");
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            try
            {
                var res = this._favColorRepo.GetPerson(id);
                return Ok(ConvertJson(res));
            }
            catch (PersonNotExistException )
            {
                var logger = _loggerFactory.CreateLogger("NoPerson");
                logger.LogWarning("No Person Found with given id = " + id);
                return StatusCode(StatusCodes.Status404NotFound, "No Person Found with given id = " + id);
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger("Unhandled Exception");
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("color/{color}")]
        public ActionResult<IEnumerable<Person>> GetPersonByFavourColorId(string color)
        {
            try
            {
                var res = this._favColorRepo.GetPeopleByColor(color);
                return Ok(ConvertJson(res));
            }
            catch (ColorNotExistException )
            {
                var logger = _loggerFactory.CreateLogger("NoColor");
                logger.LogWarning("No color Found with given name = " + color);
                return StatusCode(StatusCodes.Status404NotFound, "No color Found with given name = " + color);
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger("Unhandled Exception");
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPost]
        public ActionResult<IEnumerable<Person>> SavePeople(IEnumerable<PersonSaveDTO> peopleDt)
        {
            try
            {
                var people = _imapper.Map<IEnumerable<Person>>(peopleDt);
                this._favColorRepo.SavePeople(people);
                return Ok(ConvertJson(people));
            }catch(NoPeopleForUpdateException)
            {
                var logger = _loggerFactory.CreateLogger("NoPeople");
                logger.LogError("No People found in post payload.");
                return StatusCode(StatusCodes.Status404NotFound, "No People found in post payload.");
            }catch (ColorIsNullException)
            {
                var logger = _loggerFactory.CreateLogger("NoColor");
                logger.LogError("Colorname is not given in post payload or doesn't exist in database/csv.");
                return StatusCode(StatusCodes.Status404NotFound, "Colorname is not given in post payload or doesn't exist in database/csv.");
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger("Unhandled Exception");
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }

}
