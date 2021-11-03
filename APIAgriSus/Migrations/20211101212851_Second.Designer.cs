﻿// <auto-generated />
using APIAgriSus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIAgriSus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211101212851_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("APIAgriSus.Models.Agricultor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("avaliacao")
                        .HasColumnType("float");

                    b.Property<string>("cnpj")
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("imagem")
                        .HasColumnType("longtext");

                    b.Property<string>("motivacao")
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.Property<float>("numeroDeAvaliacao")
                        .HasColumnType("float");

                    b.Property<string>("telefone")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Agricultores");
                });

            modelBuilder.Entity("APIAgriSus.Models.userfisico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("nomeuser")
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UserFisco");
                });
#pragma warning restore 612, 618
        }
    }
}