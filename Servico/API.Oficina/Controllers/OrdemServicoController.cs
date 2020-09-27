using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Oficina.ViewModel;
using Infra.Data.Contexto;
using AutoMapper;
using Modelo.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Modelo.Dominio.Interfaces.Servicos;
using Modelo.Dominio.ValueObjects;
using Microsoft.AspNetCore.SignalR;
using API.Oficina.Hubs;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]

    public class OrdemServicoController : ControllerBase , IDisposable
    {
        
        private readonly IMapper _mapper;
        private readonly IOrdemServicoServico _servico;
        private readonly IHubContext<OSHub> _hub;

        public OrdemServicoController(IOrdemServicoServico servico, IMapper mapper, IHubContext<OSHub> hub)
        {
            _servico = servico;
            _mapper = mapper;
            _hub = hub;
        }


        [Route("[action]/{documento}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoViewModel>>> BuscarPorDocumento(string documento)
        {
            var retorno = await _servico.BuscarPorDocumento(documento);
            if (retorno != null)
                return Ok(_mapper.Map<IEnumerable<OrdemServicoViewModel>>(retorno));
            else return NotFound();
        }


        [Route("[action]/{referencia}")]
        [HttpPatch]
        public async Task<ActionResult<OrdemServicoViewModel>> AtualizarStatus([FromBody]BasicOrdemServicoViewModel vm,string referencia)
        {

            var result = await _servico.AtualizarStatus(_mapper.Map<BasicOrdemServico>(vm), referencia);
            if (result != null)
            {

                if (vm.Status == 2 )
                {
                    var menssagem = $"OS {referencia} - {(vm.Aprovacao?"Aprovada":"Reprovada")}";
                    await _hub.Clients.All.SendAsync("ReceberOSStatus",menssagem);
                }
                return Ok(_mapper.Map<OrdemServicoViewModel>(result));

            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("[action]/{status}")]
        public async Task<ActionResult<IEnumerable<OrdemServicoViewModel>>> BuscarPorStatus(string status = null)
        {
            var retorno = await _servico.BuscarPorStatus(status);
            if (retorno != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrdemServicoViewModel>>(retorno));
            }
            else
            {
                return BadRequest();
              
            }
        }

        // GET: api/OrdemServico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoViewModel>>> GetOrdemServico()
        {
           
                return Ok( _mapper.Map<List<OrdemServicoViewModel>>(
              await _servico.ListarComInclude()));
            
        }

        // GET: api/OrdemServico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoViewModel>> GetOrdemServico(string id)
        {
            var ordemServico = await _servico.ObterComInclude(id);

            if (ordemServico == null)
            {
                return NotFound();
            }

            return _mapper.Map<OrdemServicoViewModel>(ordemServico);
        }

        // PUT: api/OrdemServico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemServico(int id, OrdemServicoViewModel ordemServico)
        {
            if (id != ordemServico.Id)
            {
                return BadRequest();
            }

            if (await _servico.ExisteAsync(id))
            {
                var vm = await _servico.AtualizarAsync(_mapper.Map<OrdemServico>(ordemServico));
                return Ok(_mapper.Map<OrdemServicoViewModel>(vm));
            }
            else return NotFound();
 
        }

        // POST: api/OrdemServico
        [HttpPost]
        public async Task<ActionResult<OrdemServicoViewModel>> PostOrdemServico(OrdemServicoViewModel ordemServico)
        {
            var vm = await _servico.InserirOrdemServico(_mapper.Map<OrdemServico>(ordemServico));
            if (vm != null)
                return Ok(_mapper.Map<OrdemServicoViewModel>(vm));
            else return NotFound();
        }

        // DELETE: api/OrdemServico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdemServicoViewModel>> DeleteOrdemServico(int id)
        {
            var ordemServico = await _servico.ObterAsync(id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            await _servico.RemoverAsync(id);
            return Ok(new { Status = "Ok" });
        }

        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
