﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoolApi.Data;

namespace PoolApi.Migrations
{
    [DbContext(typeof(PoolContext))]
    [Migration("20200310182230_OptionDataBase")]
    partial class OptionDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("PoolApi.Option", b =>
                {
                    b.Property<int>("option_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("option_description")
                        .HasColumnType("TEXT");

                    b.Property<int>("poll_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("option_id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("PoolApi.Pool", b =>
                {
                    b.Property<int>("poll_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("poll_description")
                        .HasColumnType("TEXT");

                    b.HasKey("poll_id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
