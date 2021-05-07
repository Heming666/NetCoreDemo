﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.EF;

namespace Repository.EF.Migrations
{
    [DbContext(typeof(MSSQLDBContext))]
    partial class MSSQLDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Entity.Models.Base.DepartmentEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeptId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ID" }, "Index_ID");

                    b.ToTable("Base_Department");

                    b
                        .HasComment("部门表");
                });

            modelBuilder.Entity("Repository.Entity.Models.Base.UserEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("主键")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasComment("账户");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentEntityID")
                        .HasColumnType("int");

                    b.Property<int?>("DeptInfoID")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int")
                        .HasComment("性别");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasComment("密码");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasComment("手机号");

                    b.Property<string>("Photo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("照片");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasComment("用户昵称");

                    b.HasKey("ID");

                    b.HasIndex("Account")
                        .IsUnique();

                    b.HasIndex("DepartmentEntityID");

                    b.HasIndex("DeptInfoID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex(new[] { "Account" }, "Index_Account");

                    b.ToTable("Base_UserInfo");

                    b
                        .HasComment("用户信息表");
                });

            modelBuilder.Entity("Repository.Entity.Models.Consume.ConsumeEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(8,2)")
                        .HasComment("金额");

                    b.Property<int>("Classify")
                        .HasColumnType("int")
                        .HasComment("分类");

                    b.Property<string>("ConsumeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("消费名称");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<DateTime>("LogTime")
                        .HasColumnType("datetime2")
                        .HasComment("消费时间");

                    b.Property<string>("Place")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("消费地点");

                    b.Property<string>("Remark")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("备注");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex(new[] { "ID" }, "Index_ID")
                        .HasDatabaseName("Index_ID1");

                    b.ToTable("User_ConsumeEntity");

                    b
                        .HasComment("消费支出明细表");
                });

            modelBuilder.Entity("Repository.Entity.Models.Base.UserEntity", b =>
                {
                    b.HasOne("Repository.Entity.Models.Base.DepartmentEntity", null)
                        .WithMany("Users")
                        .HasForeignKey("DepartmentEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entity.Models.Base.DepartmentEntity", "DeptInfo")
                        .WithMany()
                        .HasForeignKey("DeptInfoID");

                    b.Navigation("DeptInfo");
                });

            modelBuilder.Entity("Repository.Entity.Models.Consume.ConsumeEntity", b =>
                {
                    b.HasOne("Repository.Entity.Models.Base.UserEntity", "User")
                        .WithMany("ConsumeEntitys")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Entity.Models.Base.DepartmentEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Repository.Entity.Models.Base.UserEntity", b =>
                {
                    b.Navigation("ConsumeEntitys");
                });
#pragma warning restore 612, 618
        }
    }
}
