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

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class MecanicoController : ControllerBase,IDisposable
    {
        private readonly IMecanicoServico _servico;
        private readonly IClienteServico _clienteServico;
        private readonly IMapper _mapper;


        public MecanicoController(IMecanicoServico servico,IMapper mapper,IClienteServico clienteServico)
        {
            _servico = servico;
            _mapper = mapper;
            _clienteServico = clienteServico;
        }

        // GET: api/Mecanico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MecanicoViewModel>>> GetMecanico()
        {
            return _mapper.Map<List<MecanicoViewModel>>(await _servico.ListarAsync());
        }

        // GET: api/Mecanico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MecanicoViewModel>> GetMecanico(int id)
        {
            var mecanico = await _servico.ObterAsync(id);

            if (mecanico == null)
            {
                return NotFound();
            }

            return _mapper.Map<MecanicoViewModel>(mecanico);
        }

        // PUT: api/Mecanico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanico(int id, MecanicoViewModel mecanico)
        {
            if (id != mecanico.Id)
            {
                return BadRequest();
            }

            if (await _servico.ExisteAsync(mecanico.Id))
            {
                var vm = _servico.AtualizarAsync(_mapper.Map<Mecanico>(mecanico));
                return Ok(_mapper.Map<MecanicoViewModel>(vm));
            }
            else return NotFound();
        }

        // POST: api/Mecanico
        [HttpPost]
        public async Task<ActionResult<MecanicoViewModel>> PostMecanico(MecanicoViewModel mecanico)
        {

            var mecanicoExiste = await _servico.ExisteFiltroAsync(x => x.Login == mecanico.Login);
            var clienteExiste = await _clienteServico.ExisteFiltroAsync(x => x.Email == mecanico.Login);

            if (mecanicoExiste == true || clienteExiste == true)
            {
                return BadRequest(new { erro = "Email já exite!" });
            }

            var item = await _servico.AdicionarAsync(_mapper.Map<Mecanico>(mecanico));

            return Ok(_mapper.Map<MecanicoViewModel>(item));
        }

        // DELETE: api/Mecanico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MecanicoViewModel>> DeleteMecanico(int id)
        {
            await _servico.RemoverAsync(id);
            return Ok(new { Status = "Ok" });
        }

    

        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
