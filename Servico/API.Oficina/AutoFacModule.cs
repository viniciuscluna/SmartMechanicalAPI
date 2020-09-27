using Autofac;
using Infra.Comum.Email.Interfaces;
using Infra.Comum.Email.Servicos;
using Infra.Data.Repositorios;
using Modelo.Dominio.Interfaces.Repositorios;
using Modelo.Dominio.Interfaces.Servicos;
using Modelo.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Oficina
{
    public class AutoFacModule : Module
    {
       
        protected override void Load(ContainerBuilder builder)
        {
            //Autenticar
            builder.RegisterType<AutenticacaoServico>().As<IAutenticacaoServico>();

            //Carro
            builder.RegisterType<CarroRepositorio>().As<ICarroRepositorio>();
            builder.RegisterType<CarroServico>().As<ICarroServico>();

            //Cliente
            builder.RegisterType<ClienteRepositorio>().As<IClienteRepositorio>();
            builder.RegisterType<ClienteServico>().As<IClienteServico>();

            //Mecanico
            builder.RegisterType<MecanicoRepositorio>().As<IMecanicoRepositorio>();
            builder.RegisterType<MecanicoServico>().As<IMecanicoServico>();

            //Oficina
            builder.RegisterType<OficinaRepositorio>().As<IOficinaRepositorio>();
            builder.RegisterType<OficinaServico>().As<IOficinaServico>();

            //Servico
            builder.RegisterType<ServicoRepositorio>().As<IServicoRepositorio>();
            builder.RegisterType<ServicoServico>().As<IServicoServico>();

            //Ordem Servico
            builder.RegisterType<OrdemServicoRepositorio>().As<IOrdemServicoRepositorio>();
            builder.RegisterType<OrdemServicoServico>().As<IOrdemServicoServico>();

            //PerguntaOS
            builder.RegisterType<PerguntaOSRepositorio>().As<IPerguntaOSRepositorio>();
            builder.RegisterType<PerguntaOSServico>().As<IPerguntaOSServico>();

            //PreOrdemServico
            builder.RegisterType<PreOrdemServicoRepositorio>().As<IPreOrdemServicoRepositorio>();
            builder.RegisterType<PreOrdemServicoServico>().As<IPreOrdemServicoServico>();

            builder.RegisterType<EmailServico>().As<IEmailServico>();
        }
    }
}
