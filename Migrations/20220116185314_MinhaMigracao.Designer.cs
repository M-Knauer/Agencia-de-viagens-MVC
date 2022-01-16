﻿// <auto-generated />
using GoodTrip.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodTrip.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220116185314_MinhaMigracao")]
    partial class MinhaMigracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GoodTrip.Models.Cliente", b =>
                {
                    b.Property<int>("Id_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_cliente"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id_cliente");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("GoodTrip.Models.Passagem", b =>
                {
                    b.Property<int>("Id_pass")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_pass"), 1L, 1);

                    b.Property<string>("Desembarque")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Embarque")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Id_cliente_pass")
                        .HasColumnType("int");

                    b.Property<decimal>("Preço")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id_pass");

                    b.HasIndex("Id_cliente_pass");

                    b.ToTable("Passagem", (string)null);
                });

            modelBuilder.Entity("GoodTrip.Models.Passagem", b =>
                {
                    b.HasOne("GoodTrip.Models.Cliente", "Cliente")
                        .WithMany("Passagens")
                        .HasForeignKey("Id_cliente_pass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GoodTrip.Models.Cliente", b =>
                {
                    b.Navigation("Passagens");
                });
#pragma warning restore 612, 618
        }
    }
}