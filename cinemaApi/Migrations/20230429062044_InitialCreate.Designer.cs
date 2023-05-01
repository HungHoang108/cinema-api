﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cinemaApi.Database;

#nullable disable

namespace cinemaApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230429062044_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cinemaApi.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClosingHour")
                        .HasColumnType("integer")
                        .HasColumnName("closing_hour");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OpeningHour")
                        .HasColumnType("integer")
                        .HasColumnName("opening_hour");

                    b.Property<int>("ShowDuration")
                        .HasColumnType("integer")
                        .HasColumnName("show_duration");

                    b.HasKey("Id")
                        .HasName("pk_cinemas");

                    b.ToTable("cinemas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
