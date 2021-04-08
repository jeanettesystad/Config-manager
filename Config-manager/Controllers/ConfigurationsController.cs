using Microsoft.AspNetCore.Mvc;
//using System;
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

        /*
        // POST api/productsuggestions
        [HttpPost]
        public ActionResult<ProductSuggestion> InsertProductSuggestion(ProductSuggestion item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                ProductSuggestion result = repository.Insert(item);
                return CreatedAtAction("ProductSuggestionById", new { id = result.Id }, result);
            }
        }

        // PUT api/productsuggestions/2
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductSuggestion item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else if (repository.Update(item))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/productsuggestions/2
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (repository.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        */

        #endregion


        #region Environmen APIs
        [HttpGet("getEnvironments")]
        public ActionResult<IEnumerable<Environment>> GetEnvironments()
        {
            return Ok(repository.Environments);
        }

        
        [HttpPost("postEnvironment")]
        public ActionResult<Environment> Insert(Environment environment)
        {
            if (environment == null)
            {
                return BadRequest();
            }
            else
            {
                repository.InsertEnvironment(environment);

                return Ok(environment);
            }
        }




        #endregion

    }
}
