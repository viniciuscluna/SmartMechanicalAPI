using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Oficina.ViewModel;
using AutoMapper;
using Infra.Data.Contexto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Servicos;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class ClienteController : ControllerBase,IDisposable
    {
        private readonly IClienteServico _servico;
        private readonly IMecanicoServico _mecanicoServico;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServico servico, IMapper mapper,IMecanicoServico mecanicoServico)
        {
            _servico = servico;
            _mapper = mapper;
            _mecanicoServico = mecanicoServico;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> GetCliente()
        {
            return _mapper.Map<List<ClienteViewModel>>(await _servico.ListarAsync());
        }
      

        [Route("[action]/{documento}")]
        [HttpGet]
        public async Task<ActionResult<ClienteViewModel>> BuscarPorDocumento(string documento = null)
        {
            if (documento != null)
            {
                return Ok(_mapper.Map<ClienteViewModel>(await _servico.GetWithIncludeAsync(documento)));
            }
            else
            {
                return NotFound();
            }
        }

        [Route("[action]/{email}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(_mapper.Map<ClienteViewModel>(await _servico.GetByEmail(email)));
        }
        

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> GetCliente(string id)
        {
            var cliente = await _servico.GetWithIncludeAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteViewModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            if (!(await _servico.ExisteAsync(id)))
            {
                return NotFound();
            }
            else
            {
                await _servico.AtualizarAsync(_mapper.Map<Cliente>(cliente));
                return Ok(_mapper.Map<ClienteViewModel>(cliente));
            }
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> PostCliente(ClienteViewModel cliente)
        {

            var mecanicoExiste = await _mecanicoServico.ExisteFiltroAsync(f=>f.Login==cliente.Email);
            var clienteExiste = await _servico.ExisteFiltroAsync(f => f.Email == cliente.Email);

            if (mecanicoExiste == true || clienteExiste == true)
            {
                return BadRequest(new { erro = "Email já exite!" });
            }

            Random random = new Random();
            int randomNumber = random.Next(0, 10000);
            var cliente2 = _mapper.Map<Cliente>(cliente);
            cliente2.Senha = randomNumber.ToString();

            cliente2 = await _servico.AdicionarAsync(cliente2);

            return Ok(_mapper.Map<ClienteViewModel>(cliente2));
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteViewModel>> DeleteCliente(int id)
        {
            if (await _servico.RemoverAsync(id))
                return Ok(new { Status = "Ok"});
            else return NotFound();
        }

        public void Dispose()
        {
            _servico.Dispose();
            _mecanicoServico.Dispose();
        }
    }
}
