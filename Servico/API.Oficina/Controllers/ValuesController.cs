using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Oficina.Hubs;
using API.Oficina.Services;
using Infra.Comum.Email.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHubContext<OSHub> _hub;
        private readonly IEmailServico _emailServico;
        public ValuesController(IHubContext<OSHub> hub,IEmailServico emailServico)
        {

            _hub = hub;
            _emailServico = emailServico;
        }
        // GET api/values
        [HttpGet]
        public async Task< ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {

            return id.ToString();
        }

    
       
    }
}
