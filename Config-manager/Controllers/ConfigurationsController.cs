using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;


namespace Config_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private IConfigdataRepository repository;

        public ConfigurationsController(IConfigdataRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Configdata>> Get()
        {
            return Ok(repository.Configdatas);
        }

        [HttpGet("{id}")]
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

        
        
    }
}
