﻿// <auto-generated />
using System;
using Investimentos.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Investimentos.Persistence.Migrations
{
    [DbContext(typeof(InvestimentoContext))]
    [Migration("20210819133846_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Investimentos.Domain.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ativo");
                });

            modelBuilder.Entity("Investimentos.Domain.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AtivoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataVenda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdCompra")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QtdVenda")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ValorVenda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AtivoId");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("Investimentos.Domain.Transacao", b =>
                {
                    b.HasOne("Investimentos.Domain.Ativo", "Ativo")
                        .WithMany("Transacao")
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ativo");
                });

            modelBuilder.Entity("Investimentos.Domain.Ativo", b =>
                {
                    b.Navigation("Transacao");
                });
#pragma warning restore 612, 618
        }
    }
}
