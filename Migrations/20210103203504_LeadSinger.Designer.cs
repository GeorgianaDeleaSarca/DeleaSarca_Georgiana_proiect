﻿// <auto-generated />
using System;
using DeleaSarca_Georgiana_proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeleaSarca_Georgiana_proiect.Migrations
{
    [DbContext(typeof(DeleaSarca_Georgiana_proiectContext))]
    [Migration("20210103203504_LeadSinger")]
    partial class LeadSinger
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeadSinger")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.RecordLabel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecordLabelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RecordLabel");
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstRelease")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecordLabelID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("WeeksInTop40")
                        .HasColumnType("decimal(6, 1)");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("RecordLabelID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.SongGenre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("SongID");

                    b.ToTable("SongGenre");
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.Song", b =>
                {
                    b.HasOne("DeleaSarca_Georgiana_proiect.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeleaSarca_Georgiana_proiect.Models.RecordLabel", "RecordLabel")
                        .WithMany("Songs")
                        .HasForeignKey("RecordLabelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeleaSarca_Georgiana_proiect.Models.SongGenre", b =>
                {
                    b.HasOne("DeleaSarca_Georgiana_proiect.Models.Genre", "Genre")
                        .WithMany("SongGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeleaSarca_Georgiana_proiect.Models.Song", "Song")
                        .WithMany("SongGenres")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
