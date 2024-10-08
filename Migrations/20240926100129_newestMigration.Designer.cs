﻿// <auto-generated />
using Devopsweb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Devopsweb.Migrations
{
    [DbContext(typeof(SkillsDbContext))]
    [Migration("20240926100129_newestMigration")]
    partial class newestMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Devopsweb.Models.SkillsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "MySQL"
                        },
                        new
                        {
                            Id = 2,
                            Title = "HTML"
                        },
                        new
                        {
                            Id = 3,
                            Title = "CSS"
                        },
                        new
                        {
                            Id = 4,
                            Title = "JavaScript"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Java"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Kotlin"
                        },
                        new
                        {
                            Id = 7,
                            Title = "C#"
                        },
                        new
                        {
                            Id = 8,
                            Title = "OOP"
                        },
                        new
                        {
                            Id = 9,
                            Title = "JSON"
                        },
                        new
                        {
                            Id = 10,
                            Title = "JDBC"
                        },
                        new
                        {
                            Id = 11,
                            Title = "Github"
                        },
                        new
                        {
                            Id = 12,
                            Title = "Bootstrap"
                        },
                        new
                        {
                            Id = 13,
                            Title = "Spring Framework"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
