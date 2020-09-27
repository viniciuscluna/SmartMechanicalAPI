﻿// <auto-generated />
using System;
using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(OficinaContext))]
    [Migration("20200606170147_TipoPreAbertura")]
    partial class TipoPreAbertura
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Dominio.Entidades.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<string>("Placa");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfCnpj");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<int>("OficinaId");

                    b.Property<string>("PerfilSistema");

                    b.Property<string>("Senha");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("OficinaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Mecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<int>("OficinaId");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

                    b.HasIndex("OficinaId");

                    b.ToTable("Mecanico");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Oficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Oficina");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.OrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprovacao");

                    b.Property<int>("CarroId");

                    b.Property<DateTime>("DataAbertura");

                    b.Property<string>("ProblemaDescrito");

                    b.Property<string>("ProblemaRelatado");

                    b.Property<string>("Referencia");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.PerguntaOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pergunta");

                    b.Property<bool>("PerguntaInicial");

                    b.HasKey("Id");

                    b.ToTable("PerguntaOS");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.PerguntaOSAlternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alternativa");

                    b.Property<bool>("AlternativaFinal");

                    b.Property<int>("PerguntaOSId");

                    b.Property<int?>("PreAberturaOSId");

                    b.Property<int?>("ProximaPerguntaOSId");

                    b.HasKey("Id");

                    b.HasIndex("PerguntaOSId");

                    b.HasIndex("PreAberturaOSId");

                    b.HasIndex("ProximaPerguntaOSId");

                    b.ToTable("PerguntaOSAlternativa");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.PreAberturaOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto");

                    b.Property<string>("Descricao");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("PreAberturaOS");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.ServicoOrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoServico");

                    b.Property<int>("OrdemServicoId");

                    b.Property<int>("ServicoId");

                    b.Property<double>("ValorServico");

                    b.HasKey("Id");

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoOrdemServico");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Carro", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.Oficina", "Oficina")
                        .WithMany()
                        .HasForeignKey("OficinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.Mecanico", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.Oficina", "Oficina")
                        .WithMany()
                        .HasForeignKey("OficinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.OrdemServico", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.PerguntaOSAlternativa", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.PerguntaOS", "PerguntaOS")
                        .WithMany()
                        .HasForeignKey("PerguntaOSId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Modelo.Dominio.Entidades.PreAberturaOS", "PreAberturaOS")
                        .WithMany()
                        .HasForeignKey("PreAberturaOSId");

                    b.HasOne("Modelo.Dominio.Entidades.PerguntaOS", "ProximaPerguntaOS")
                        .WithMany()
                        .HasForeignKey("ProximaPerguntaOSId");
                });

            modelBuilder.Entity("Modelo.Dominio.Entidades.ServicoOrdemServico", b =>
                {
                    b.HasOne("Modelo.Dominio.Entidades.OrdemServico", "OrdemServico")
                        .WithMany("Servicos")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Modelo.Dominio.Entidades.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
