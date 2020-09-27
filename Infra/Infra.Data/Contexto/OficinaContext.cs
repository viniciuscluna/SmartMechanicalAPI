using Microsoft.EntityFrameworkCore;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Contexto
{
   public  class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options)
            : base(options)
        { }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Oficina> Oficina { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ServicoOrdemServico> ServicoOrdemServico { get; set; }
        public DbSet<Mecanico> Mecanico { get; set; }

        public DbSet<PerguntaOS> PerguntaOS { get; set; }
        public DbSet<PerguntaOSAlternativa> PerguntaOSAlternativa { get; set; }

        public DbSet<PreAberturaOS> PreAberturaOS { get; set; }

        public DbSet<PreOrdemServico> PreOrdemServico { get; set; }



    }
}
