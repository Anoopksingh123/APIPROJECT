using APIPROJECT.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPROJECT.Contract;

namespace APIPROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        
        public ValuesController( ILogger<EmployeeController> logger)
        {
          
            _logger = logger;

        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
           
                string[] arrRetValues = null;
                if (arrRetValues.Length > 0)
                { }
               
                //_logger.LogError(ex.ToString());
                
           if(Response.StatusCode== 200){
                return arrRetValues;
            }
            else
            {
                _logger.LogError(Response.ToString());
            }
            return null;
        }
    }
}
