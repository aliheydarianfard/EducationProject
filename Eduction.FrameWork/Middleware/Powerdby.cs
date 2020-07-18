using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.FrameWork.Middleware
{
   public class Powerdby
    {
        private readonly RequestDelegate _next;

        public Powerdby(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext) 
        {
            httpContext.Response.Headers["X-Powered-By"] = "Ali Heydarianfard";
            return _next.Invoke(httpContext);
        }
    }
}
