﻿// <auto-generated />
using System;
using F1GrandPrixApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230913174842_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("F1GrandPrixApi.Models.Drzava", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("drzave");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Grad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("gradovi");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Kupac", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("adresa1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adresa2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("drzavaid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kompanija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postanskiBroj")
                        .HasColumnType("int");

                    b.Property<string>("potvrdaEmailAdrese")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("promoKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("drzavaid");

                    b.ToTable("kupci");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Rezervacija", b =>
                {
                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<int>("TrkaId")
                        .HasColumnType("int");

                    b.Property<bool>("aktivna")
                        .HasColumnType("bit");

                    b.Property<int>("brojKarata")
                        .HasColumnType("int");

                    b.Property<decimal>("konacnaCena")
                        .HasColumnType("decimal(10,4)");

                    b.Property<int>("popust")
                        .HasColumnType("int");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("zonaid")
                        .HasColumnType("int");

                    b.HasKey("KupacId", "TrkaId");

                    b.HasIndex("TrkaId");

                    b.HasIndex("zonaid");

                    b.ToTable("rezervacije");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Trka", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("dodatneInformacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gradid")
                        .HasColumnType("int");

                    b.Property<string>("lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("gradid");

                    b.ToTable("trke");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Ucesce", b =>
                {
                    b.Property<int>("UcesnikId")
                        .HasColumnType("int");

                    b.Property<int>("TrkaId")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("UcesnikId", "TrkaId");

                    b.HasIndex("TrkaId");

                    b.ToTable("ucesca");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Ucesnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ucesnici");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Zona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("cenaKarte")
                        .HasColumnType("decimal(10,4)");

                    b.Property<int>("kapacitet")
                        .HasColumnType("int");

                    b.Property<bool>("pogodnaZaInvalide")
                        .HasColumnType("bit");

                    b.Property<int>("preostaloMesta")
                        .HasColumnType("int");

                    b.Property<bool>("velikiTV")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("zone");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Kupac", b =>
                {
                    b.HasOne("F1GrandPrixApi.Models.Drzava", "drzava")
                        .WithMany("kupci")
                        .HasForeignKey("drzavaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("drzava");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Rezervacija", b =>
                {
                    b.HasOne("F1GrandPrixApi.Models.Kupac", "kupac")
                        .WithMany("rezervacije")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1GrandPrixApi.Models.Trka", "trka")
                        .WithMany("rezervacije")
                        .HasForeignKey("TrkaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1GrandPrixApi.Models.Zona", "zona")
                        .WithMany("rezervacije")
                        .HasForeignKey("zonaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kupac");

                    b.Navigation("trka");

                    b.Navigation("zona");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Trka", b =>
                {
                    b.HasOne("F1GrandPrixApi.Models.Grad", "grad")
                        .WithMany("trke")
                        .HasForeignKey("gradid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grad");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Ucesce", b =>
                {
                    b.HasOne("F1GrandPrixApi.Models.Trka", "trka")
                        .WithMany("ucesca")
                        .HasForeignKey("TrkaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1GrandPrixApi.Models.Ucesnik", "ucesnik")
                        .WithMany("ucesca")
                        .HasForeignKey("UcesnikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("trka");

                    b.Navigation("ucesnik");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Drzava", b =>
                {
                    b.Navigation("kupci");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Grad", b =>
                {
                    b.Navigation("trke");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Kupac", b =>
                {
                    b.Navigation("rezervacije");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Trka", b =>
                {
                    b.Navigation("rezervacije");

                    b.Navigation("ucesca");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Ucesnik", b =>
                {
                    b.Navigation("ucesca");
                });

            modelBuilder.Entity("F1GrandPrixApi.Models.Zona", b =>
                {
                    b.Navigation("rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
