using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIPROJECT.Model;
namespace APIPROJECT.Extension
{
    public static class GlobalErrorHandling
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.CreateLogger($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetail()
                        {
                            StatusCode = context.Response.StatusCode,
                        //    Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}

