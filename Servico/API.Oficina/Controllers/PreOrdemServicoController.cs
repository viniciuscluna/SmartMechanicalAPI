using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Oficina.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Dominio.Interfaces.Servicos;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreOrdemServicoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPreOrdemServicoServico _preOrdemServicoServico;
        public PreOrdemServicoController(IMapper mapper, IPreOrdemServicoServico preOrdemServicoServico)
        {
            _mapper = mapper;
            _preOrdemServicoServico = preOrdemServicoServico;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PreOrdemServicoViewModel>>(await _preOrdemServicoServico.ListarComIncludeAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<PreOrdemServicoViewModel>(await _preOrdemServicoServico.ObterAsync(id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _preOrdemServicoServico.RemoverAsync(id);
            if (result)
                return Ok();
            else return BadRequest();
        }
    }
}
