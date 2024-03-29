﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopManagement.Infrastructure.EfCore.Context;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20230628214425_AtlasMigration")]
    partial class AtlasMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopManagement.Domain.ProductCategoryAggregate.ProductCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KeyWords")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("PictureAlt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "01H41ZDYQBQR2N6T193C5Z7G9K",
                            CreationDate = "1402/4/7",
                            Description = "Test",
                            KeyWords = "Test",
                            MetaDescription = "Test",
                            Name = "Test",
                            Picture = "Test",
                            PictureAlt = "Test",
                            PictureTitle = "Test",
                            Slug = "Test",
                            Status = (byte)1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
