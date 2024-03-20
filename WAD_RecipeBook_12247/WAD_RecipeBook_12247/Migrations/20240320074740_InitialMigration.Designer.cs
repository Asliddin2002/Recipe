﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAD_RecipeBook_12247.Data;

#nullable disable

namespace WAD_RecipeBook_12247.Migrations
{
    [DbContext(typeof(GeneralDBContext))]
    [Migration("20240320074740_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WAD_RecipeBook_12247.Models.Ingredients", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("WAD_RecipeBook_12247.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("WAD_RecipeBook_12247.Models.Ingredients", b =>
                {
                    b.HasOne("WAD_RecipeBook_12247.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID");

                    b.Navigation("Recipe");
                });
#pragma warning restore 612, 618
        }
    }
}