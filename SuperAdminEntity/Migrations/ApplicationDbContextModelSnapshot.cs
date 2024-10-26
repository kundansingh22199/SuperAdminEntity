﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperAdminEntity.EF;

#nullable disable

namespace SuperAdminEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperAdminEntity.Models.ControlMst", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("activate")
                        .HasColumnType("int");

                    b.Property<int?>("awards")
                        .HasColumnType("int");

                    b.Property<int?>("changepassword")
                        .HasColumnType("int");

                    b.Property<int?>("changeprofile")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("news")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("payout")
                        .HasColumnType("int");

                    b.Property<int?>("pingeneration")
                        .HasColumnType("int");

                    b.Property<int?>("reports")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("ControlMst");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_DomainMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Connection")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("createdate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Tbl_DomainMaster");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_Master_Binary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CappingType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Inc_capping")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inc_fix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inc_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inc_per_id")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Inc_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ratio")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Tbl_Master_Binary");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_Master_Direct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Inc_after_id")
                        .HasColumnType("int");

                    b.Property<int?>("Inc_all_id")
                        .HasColumnType("int");

                    b.Property<decimal?>("Inc_fix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inc_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Inc_per_id")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Inc_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Tbl_Master_Direct");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_Master_Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Direct_id_require")
                        .HasColumnType("int");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Inc_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Level_No")
                        .HasColumnType("int");

                    b.Property<decimal?>("Level_fix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Level_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Master_Level");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_Master_LevelOnRoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Direct_id_require")
                        .HasColumnType("int");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Inc_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Level_No")
                        .HasColumnType("int");

                    b.Property<decimal?>("Level_fix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Level_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Master_LevelOnRoi");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_Master_Roi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoiDay")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("inc_recuring")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal?>("max_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("min_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("random")
                        .HasColumnType("bit");

                    b.Property<decimal?>("roi_fix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("roi_per")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("roi_type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("roi_upto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("sunday_saturday_off")
                        .HasColumnType("bit");

                    b.Property<bool?>("sundayoff")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Tbl_Master_Roi");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_PackageMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("createdate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Tbl_PackageMaster");
                });

            modelBuilder.Entity("SuperAdminEntity.Models.Tbl_UserPrefix", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RegPrefix")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TotalDigit")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Tbl_UserPrefix");
                });
#pragma warning restore 612, 618
        }
    }
}
