﻿// <auto-generated />
using System;
using HealthMed.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthMed.Infraestructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthMed.Domain.Entities.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("Agendas", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.AgendaDia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("AgendaDias", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgendaDiaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AgendaDiaId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.HorarioConsulta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgendaDiaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("AgendaDiaId");

                    b.ToTable("HorarioConsultas", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Medicos", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("HealthMed.Domain.Entities.Medico", "Medico")
                        .WithMany("Agendas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.AgendaDia", b =>
                {
                    b.HasOne("HealthMed.Domain.Entities.Agenda", "Agenda")
                        .WithMany("Dias")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agenda");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("HealthMed.Domain.Entities.AgendaDia", "AgendaDia")
                        .WithMany("Consultas")
                        .HasForeignKey("AgendaDiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthMed.Domain.Entities.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthMed.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AgendaDia");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.HorarioConsulta", b =>
                {
                    b.HasOne("HealthMed.Domain.Entities.AgendaDia", "AgendaDia")
                        .WithMany("Horarios")
                        .HasForeignKey("AgendaDiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgendaDia");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Agenda", b =>
                {
                    b.Navigation("Dias");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.AgendaDia", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Horarios");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Medico", b =>
                {
                    b.Navigation("Agendas");
                });

            modelBuilder.Entity("HealthMed.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
