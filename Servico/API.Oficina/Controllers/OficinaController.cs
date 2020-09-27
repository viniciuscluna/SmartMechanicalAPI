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
using Microsoft.AspNetCore.Authorization;
using Modelo.Dominio.Interfaces.Servicos;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class OficinaController : ControllerBase,IDisposable
    {
      
        private readonly IMapper _mapper;
        private readonly IOficinaServico _servico;

        public OficinaController(IOficinaServico servico,IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        // GET: api/Oficina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OficinaViewModel>>> GetOficina()
        {
            return _mapper.Map<List<OficinaViewModel>>(await _servico.ListarAsync());
        }

        // GET: api/Oficina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OficinaViewModel>> GetOficina(int id)
        {
            var oficina = await _servico.ObterAsync(id);

            if (oficina == null)
            {
                return NotFound();
            }

            return _mapper.Map<OficinaViewModel>(oficina);
        }

        // PUT: api/Oficina/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOficina(int id, OficinaViewModel oficina)
        {
            if (id != oficina.Id)
            {
                return BadRequest();
            }
            if (await _servico.ExisteAsync(id))
            {
                var vm = await _servico.AtualizarAsync(_mapper.Map<Modelo.Dominio.Entidades.Oficina>(oficina));
                return Ok(_mapper.Map<OficinaViewModel>(vm));
            }
            else return NotFound();
        }

        // POST: api/Oficina
        [HttpPost]
        public async Task<ActionResult<OficinaViewModel>> PostOficina(OficinaViewModel oficina)
        {
          var vm = await _servico.AdicionarAsync(_mapper.Map< Modelo.Dominio.Entidades.Oficina>(oficina));

            return CreatedAtAction("GetOficina", new { id = vm.Id }, _mapper.Map<OficinaViewModel>(vm));
        }

        // DELETE: api/Oficina/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OficinaViewModel>> DeleteOficina(int id)
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
