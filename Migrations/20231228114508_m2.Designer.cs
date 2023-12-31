﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Data;

#nullable disable

namespace asp_pro.Migrations
{
    [DbContext(typeof(entity_context))]
    [Migration("20231228114508_m2")]
    partial class m2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("asp_pro.Models.Category", b =>
                {
                    b.Property<int>("cateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cateId"), 1L, 1);

                    b.Property<string>("cateDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cateId");

                    b.ToTable("_category");
                });

            modelBuilder.Entity("asp_pro.Models.Products", b =>
                {
                    b.Property<int>("proId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("proId"), 1L, 1);

                    b.Property<int>("CateID")
                        .HasColumnType("int");

                    b.Property<string>("proDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("proId");

                    b.HasIndex("CateID");

                    b.ToTable("_product");
                });

            modelBuilder.Entity("asp_pro.Models.Products", b =>
                {
                    b.HasOne("asp_pro.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
