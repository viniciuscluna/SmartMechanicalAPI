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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoServico _servico;
        private readonly IMapper _mapper;

        public ServicoController(IServicoServico servico,IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        // GET: api/Servico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> GetServico()
        {
            return _mapper.Map<List<ServicoViewModel>>(await _servico.ListarAsync());
        }

        // GET: api/Servico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoViewModel>> GetServico(int id)
        {
            var servico = await _servico.ObterAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return _mapper.Map<ServicoViewModel>(servico);
        }

        // PUT: api/Servico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, ServicoViewModel servico)
        {
            if (id != servico.Id)
            {
                return BadRequest();
            }

            if (await _servico.ExisteAsync(id))
            {
                var vm = await _servico.AtualizarAsync(_mapper.Map<Servico>(servico));
                return Ok(_mapper.Map<ServicoViewModel>(vm));
            }
            else return NotFound();
        }

        // POST: api/Servico
        [HttpPost]
        public async Task<ActionResult<ServicoViewModel>> PostServico(ServicoViewModel servico)
        {
            var vm = await  _servico.AdicionarAsync(_mapper.Map<Servico>(servico));

            return Ok(_mapper.Map<ServicoViewModel>(vm));
        }

        // DELETE: api/Servico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoViewModel>> DeleteServico(int id)
        {
            var servico = await _servico.ObterAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            await _servico.RemoverAsync(id);

            return Ok(new { Status = "Ok" });
        }

    }
}
