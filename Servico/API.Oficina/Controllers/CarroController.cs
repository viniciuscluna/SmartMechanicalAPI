using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Oficina.ViewModel;
using AutoMapper;
using Infra.Data.Contexto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Servicos;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class CarroController : ControllerBase,IDisposable
    {
        private readonly IMapper _mapper;
        private readonly ICarroServico _carroServico;

        public CarroController(IMapper mapper,ICarroServico carroServico) 
        {
            _mapper = mapper;
            _carroServico = carroServico;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroViewModel>>> Get(string placa = null)
        {

            var query = await _carroServico.ConsultarPorPlacaAsync(placa);
            return _mapper.Map<List<CarroViewModel>>(query);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarroViewModel>> Get(int id)
        {
            var query = await _carroServico.ObterAsync(id);
            return _mapper.Map<CarroViewModel>(query);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<CarroViewModel>> Post([FromBody] CarroViewModel vm)
        {
            var item = _mapper.Map<Carro>(vm);

            await _carroServico.AdicionarAsync(item);
            return Ok(_mapper.Map<CarroViewModel>(item));
        }

        // PUT api/values/5

        public async Task<ActionResult<CarroViewModel>> Put([FromBody] CarroViewModel vm)
        {
            if (await _carroServico.ExisteAsync(vm.Id))
            {
                var item = _mapper.Map<Carro>(vm);
                await _carroServico.AtualizarAsync(item);
                return Ok(_mapper.Map<CarroViewModel>(item));
            }
            else
            {
                return NotFound(new JsonResult("Id não encontrado"));
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _carroServico.ExisteAsync(id))
            {
                await _carroServico.RemoverAsync(id);
                return Ok(new { Status = "Ok" });
            }
            else
            {
                return NotFound();
            }

        }

        [Route("[action]/{email}")]
        [HttpGet]
        public async Task<IActionResult> BuscarCarrosPorEmail(string email)
        {
            var result = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroServico.ConsultarCarrosPorEmail(email));

            if (result.Count() > 0)
                return Ok(result);
            else return NotFound();
            
        }

        public void Dispose()
        {
            _carroServico.Dispose();
        }
    }
}
