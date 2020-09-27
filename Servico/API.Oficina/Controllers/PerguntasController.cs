using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using API.Oficina.Hubs;
using API.Oficina.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Modelo.Dominio.Entidades;
using Modelo.Dominio.Interfaces.Servicos;
using static Modelo.Dominio.ValueObjects.Enums;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class PerguntasController : ControllerBase , IDisposable
    {
        private readonly IPerguntaOSServico _servico;
        private readonly IMapper _mapper;
        private readonly IHubContext<OSHub> _hub;
        public PerguntasController(IHubContext<OSHub> hub, IPerguntaOSServico servico,IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
            _hub = hub;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> IniciarQuestionario()
        {
            var result = await _servico.CarregarPerguntaInicial();
            return Ok(_mapper.Map<PerguntaOSViewModel>(result));
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> CarregarPergunta(int id)
        {
            var result = await _servico.CarregarPerguntaPorId(id);
            return Ok(_mapper.Map<PerguntaOSViewModel>(result));
        }

        [Route("[action]/{id}/{idCarro?}")]
        [HttpGet]
        public async Task<IActionResult> CarregarPreAbertura(int id,int? idCarro)
        {
            var result = await _servico.CarregarPreAberturaOS(id,idCarro);
            if(result.Tipo == (int)TipoPreAbertura.AbrirOS)
            {
                await _hub.Clients.All.SendAsync("ReceberInsercaoOrcamento", $"Orçamento Aberto :{result.Assunto}");
            }
            return Ok(_mapper.Map<PreAberturaOSViewModel>(result));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> InserirPergunta([FromBody]IEnumerable<PerguntaOSViewModel> perguntas)
        {
            var resultado = new List<PerguntaOSViewModel>();

            foreach (var pergunta in perguntas)
            {
                var result = await _servico.InserirPergunta(_mapper.Map<PerguntaOS>(pergunta));
                resultado.Add(_mapper.Map<PerguntaOSViewModel>(result));
            }

            return Ok(resultado);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> InserirAlternativa([FromBody] IEnumerable<PerguntaOSAlternativaViewModel> alternativas)
        {
            var resultado = new List<PerguntaOSAlternativaViewModel>();

            foreach (var alternativa in alternativas)
            {
                var result = await _servico.InserirAlternativa(_mapper.Map<PerguntaOSAlternativa>(alternativa));
                resultado.Add(_mapper.Map<PerguntaOSAlternativaViewModel>(result));
            }

            return Ok(resultado);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> InserirPreAbertura([FromBody] IEnumerable<PreAberturaOSViewModel> preAberturas)
        {
            var resultado = new List<PreAberturaOSViewModel>();

            foreach (var preAbertura in preAberturas)
            {
                var result = await _servico.InserirPreAbertura(_mapper.Map<PreAberturaOS>(preAbertura));
                resultado.Add(_mapper.Map<PreAberturaOSViewModel>(result));
            }

            return Ok(resultado);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
