using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("getConfigurations")]
        public ActionResult<IEnumerable<Configdata>> GetConfigdata()
        {
            return Ok(repository.Configdatas);
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

        
        [HttpGet("getEnvironments")]
        public ActionResult<IEnumerable<Domain.Entities.Environment>> GetEnvironments()
        {
            return Ok(repository.Environments);
        }
        
    }
}
