using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Implementation;
using Sol_Demo.Interface;

namespace Sol_Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IService service = null;

        public DemoController(Func<ImplementationType,IService> funcService)
        {
            //service = funcService(ImplementationType.ServiceB);
            service = funcService(ImplementationType.ServiceA);
        }

        [HttpGet("service")]
        public IActionResult OnGetService()
        {
            return base.Ok((Object)service.DoWork());
        }
    }
}