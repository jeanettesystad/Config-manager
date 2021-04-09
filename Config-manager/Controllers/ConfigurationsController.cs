using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;



namespace Config_manager.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private IConfigdataRepository repository;

        public ConfigurationsController(IConfigdataRepository repository)
        {
            this.repository = repository;
        }

        #region Configuration APIs
        [HttpGet("getConfigurations")]
        public ActionResult<IEnumerable<Configdata>> GetConfigdata()
        {    
            return Ok(repository.Configdatas);
        }

        [HttpGet("getConfigurations/{from}/{to}")]
        public ActionResult<IEnumerable<Configdata>> GetConfigdataByDate(System.DateTime from, System.DateTime to)
        {
            return Ok(repository.Configdatas.Where(c => from <= c.Timestamp && c.Timestamp <= to));
        }

        [HttpGet("getConfiguration/{id}")]
        public ActionResult<Configdata> GetById(long id)
        {
            Configdata configdata = repository.GetConfigdataById(id);
            if (configdata == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(configdata);
            }
        }

        [HttpPost("postConfiguration")]
        public ActionResult<Configdata> InsertConfig(Configdata configdata)
        {
            if (configdata == null)
            {
                return BadRequest();
            }
            else
            {
                repository.InsertConfigdata(configdata);

                return Ok(configdata);
            }
        }

        [HttpPut("putConfiguration")]
        public IActionResult UpdateConfig( [FromBody] Configdata configdata)
        {
            if (configdata == null)
            {
                return BadRequest();
            }
            else if (repository.UpdateConfigdata(configdata))
            {
                return Ok(configdata);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("deleteConfiguration/{id}")]
        public IActionResult DeleteConfig(long id)
        {
            if (repository.DeleteConfigdata(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        #endregion


        #region Environmen APIs
        [HttpGet("getEnvironments")]
        public ActionResult<IEnumerable<Environment>> GetEnvironments()
        {
            return Ok(repository.Environments);
        }

        [HttpGet("getEnvionments/{id}")]
        public ActionResult<Configdata> GetEnvironmentsById(long id)
        {
            Environment environment = repository.GetEnvironmentById(id);
            if (environment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(environment);
            }
        }

        [HttpPost("postEnvironment")]
        public ActionResult<Environment> InsertEnvironment(Environment environment)
        {
            if (environment == null)
            {
                return BadRequest();
            }
            else
            {
                environment = repository.InsertEnvironment(environment); 
                
                //repository.DeleteConfigdata(System.Convert.ToInt64(environment.Id));

                return Ok(environment);
            }
        }

        [HttpPut("putEnvironment")]
        public IActionResult UpdateEnvironment([FromBody] Environment environment)
        {
            if (environment == null)
            {
                return BadRequest();
            }
            else if (repository.UpdateEnvironment(environment))
            {
                return Ok(environment);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("deleteEnvironment/{id}")]
        public IActionResult DeleteEnvironment(long id)
        {
            if (repository.DeleteEnvironment(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region Admin
        [HttpGet("getToken/{username}")]
        public IActionResult GetToken(string username) => Ok(repository.VerifyUser(username));




        #endregion

    }
}
