﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeuProjeto.Data;

#nullable disable

namespace LsCode.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250529023214_AjusteDimensoesProduto")]
    partial class AjusteDimensoesProduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCaixa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("LsCode.API.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaixaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Caixa", b =>
                {
                    b.HasOne("Pedido", null)
                        .WithMany("Caixas")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Dimensao", "Dimensoes", b1 =>
                        {
                            b1.Property<int>("CaixaId")
                                .HasColumnType("int");

                            b1.Property<int>("Altura")
                                .HasColumnType("int");

                            b1.Property<int>("Comprimento")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Largura")
                                .HasColumnType("int");

                            b1.HasKey("CaixaId");

                            b1.ToTable("Caixas");

                            b1.WithOwner()
                                .HasForeignKey("CaixaId");
                        });

                    b.Navigation("Dimensoes")
                        .IsRequired();
                });

            modelBuilder.Entity("LsCode.API.Models.Produto", b =>
                {
                    b.HasOne("Caixa", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CaixaId");

                    b.HasOne("Pedido", null)
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Dimensao", "Dimensoes", b1 =>
                        {
                            b1.Property<int>("ProdutoId")
                                .HasColumnType("int");

                            b1.Property<int>("Altura")
                                .HasColumnType("int");

                            b1.Property<int>("Comprimento")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Largura")
                                .HasColumnType("int");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.Navigation("Dimensoes")
                        .IsRequired();
                });

            modelBuilder.Entity("Caixa", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Pedido", b =>
                {
                    b.Navigation("Caixas");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
