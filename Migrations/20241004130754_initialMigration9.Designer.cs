﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicosTecnicos.Models;

#nullable disable

namespace ServicosTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241004130754_initialMigration9")]
    partial class initialMigration9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServicosTecnicos.Models.Chamado", b =>
                {
                    b.Property<int>("id_chamado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_chamado"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("id_funcionario")
                        .HasColumnType("int");

                    b.Property<int>("id_tecnico")
                        .HasColumnType("int");

                    b.Property<int>("patrimonio")
                        .HasColumnType("int");

                    b.HasKey("id_chamado");

                    b.HasIndex("id_funcionario");

                    b.HasIndex("id_tecnico");

                    b.HasIndex("patrimonio");

                    b.ToTable("chamado");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Departamento", b =>
                {
                    b.Property<int>("id_departamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_departamento"));

                    b.Property<string>("nome")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id_departamento");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Funcionario", b =>
                {
                    b.Property<int>("id_funcionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_funcionario"));

                    b.Property<DateOnly>("data_nascimento")
                        .HasColumnType("date");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("id_departamento")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("id_funcionario");

                    b.HasIndex("id_departamento");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Maquina", b =>
                {
                    b.Property<int>("patrimonio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("patrimonio"));

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("patrimonio");

                    b.ToTable("maquina");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Tecnico", b =>
                {
                    b.Property<int>("id_tecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_tecnico"));

                    b.Property<DateOnly>("MyProperty")
                        .HasColumnType("date");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id_tecnico");

                    b.ToTable("tecnico");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Chamado", b =>
                {
                    b.HasOne("ServicosTecnicos.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("id_funcionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicosTecnicos.Models.Tecnico", "tecnico")
                        .WithMany()
                        .HasForeignKey("id_tecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicosTecnicos.Models.Maquina", "maquina")
                        .WithMany()
                        .HasForeignKey("patrimonio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("funcionario");

                    b.Navigation("maquina");

                    b.Navigation("tecnico");
                });

            modelBuilder.Entity("ServicosTecnicos.Models.Funcionario", b =>
                {
                    b.HasOne("ServicosTecnicos.Models.Departamento", "departamento")
                        .WithMany()
                        .HasForeignKey("id_departamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("departamento");
                });
#pragma warning restore 612, 618
        }
    }
}
