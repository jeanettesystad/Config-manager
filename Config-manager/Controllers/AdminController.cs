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
    public class AdminController : ControllerBase
    {
        private IAdminRepository repository;

        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        

        

        
        
    }
}
