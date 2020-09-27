using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Oficina.Model;
using API.Oficina.Services;
using API.Oficina.ViewModel;
using AutoMapper;
using Infra.Data.Contexto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo.Dominio.Interfaces.Servicos;
using Modelo.Dominio.ValueObjects;

namespace API.Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMecanicoServico _mecanicoServico;
        private readonly IAutenticacaoServico _autenticacaoServico;
        private readonly IMapper _mapper;

        private readonly Token _token;
        public AutenticarController( Token token, IClienteServico clienteServico, IMecanicoServico mecanicoServico, IAutenticacaoServico autenticacaoServico, IMapper mapper)
        {
            
            _token = token;
            _clienteServico = clienteServico;
            _mecanicoServico = mecanicoServico;
            _autenticacaoServico = autenticacaoServico;
            _mapper = mapper;

        }



        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<EntidadeAutenticarViewModel>> GetInfo([FromBody] string token)
        {
            string secret = _token.Secret;
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            var mecanico = await _mecanicoServico.ConsultarAsync(x => x.Login == claims.Identity.Name);
            var cliente = await _clienteServico.ConsultarAsync(x => x.Email == claims.Identity.Name);
            if (mecanico != null)
            {
                return Ok(new EntidadeAutenticarViewModel()
                {
                    Email = mecanico.Login,
                    Nome = mecanico.Login,
                    Autenticado = true,
                    Senha = mecanico.Senha,
                    Role = "Mecanico"
                });
            }
            if (cliente != null)
            {
                return Ok(new EntidadeAutenticarViewModel()
                {
                    Email = cliente.Email,
                    Nome = cliente.Nome,
                    Senha = cliente.Senha,
                    Role = "Cliente",

                    Autenticado = true
                });
            }
            else
            {
                return NotFound();
            }


        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] EntidadeAutenticarViewModel request)
        {

            request = _mapper.Map<EntidadeAutenticarViewModel>(await _autenticacaoServico.AutenticarUsuario(_mapper.Map<EntidadeAutenticar>(request)));

            if (request.Autenticado == true)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,request.Nome),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role,request.Role)
                };


                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_token.Secret));

                DateTime expiration = DateTime.Now.AddDays(_token.AccessExpirationDays);

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _token.Issuer,
                    audience: _token.Audience,
                    claims: claims,
                    expires: expiration,
                    notBefore: DateTime.Now,
                    signingCredentials: creds
                    );


                return Ok(new
                {
                    authenticatedUser = request.Nome,
                    authenticatedRole = request.Role,
                    authenticatedFrom = DateTime.Now,
                    authenticatedTo = expiration,
                    clientDocument = request.Documento,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return NotFound();
            }
        }
    }
}