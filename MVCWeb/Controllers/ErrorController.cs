using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWeb.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult Error()
        {
            var exceptionHdandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionHdandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHdandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHdandlerPathFeature.Error.StackTrace;
            return View("Error");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
