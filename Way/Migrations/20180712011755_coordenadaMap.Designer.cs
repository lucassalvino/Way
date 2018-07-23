﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Way.infra.Persistencia;

namespace Way.Migrations
{
    [DbContext(typeof(WayContext))]
    [Migration("20180712011755_coordenadaMap")]
    partial class coordenadaMap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Way.infra.Mapeadores.MapCaracterizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Caracterizacao");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapCoordernada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Coordenadas");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapDocumento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Documento")
                        .HasMaxLength(30);

                    b.Property<Guid>("PessoaID");

                    b.Property<Guid>("TipoDocumentoID");

                    b.HasKey("Id");

                    b.HasIndex("PessoaID");

                    b.HasIndex("TipoDocumentoID");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapEmails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Endereco");

                    b.Property<Guid>("PessoaID");

                    b.HasKey("Id");

                    b.HasIndex("PessoaID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapPessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("PrimeiroNome");

                    b.Property<string>("Site");

                    b.Property<string>("UltimoNome");

                    b.HasKey("Id");

                    b.ToTable("MapPessoa");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapSessaoUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTimeOffset>("DataInicioSessao");

                    b.Property<Guid>("UsuarioID");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("SessaoUsuario");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapTipoDocumento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapDocumento", b =>
                {
                    b.HasOne("Way.infra.Mapeadores.MapPessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Way.infra.Mapeadores.MapTipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapEmails", b =>
                {
                    b.HasOne("Way.infra.Mapeadores.MapPessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Way.infra.Mapeadores.MapSessaoUsuario", b =>
                {
                    b.HasOne("Way.infra.Mapeadores.MapUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
