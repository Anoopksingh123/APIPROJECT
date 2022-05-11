using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        //public IActionResult Error()
        //{
        //    var exceptionHdandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        //    ViewBag.ExceptionPath = exceptionHdandlerPathFeature.Path;

        //}
    }
}
