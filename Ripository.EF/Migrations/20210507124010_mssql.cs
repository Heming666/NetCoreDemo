﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.EF.Migrations
{
    public partial class mssql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base_Department",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_Department", x => x.DeptId);
                },
                comment: "部门表");

            migrationBuilder.CreateTable(
                name: "Base_UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, comment: "账户"),
                    PassWord = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, comment: "密码"),
                    UserName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, comment: "用户昵称"),
                    Gender = table.Column<int>(type: "int", nullable: true, comment: "性别"),
                    Photo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "照片"),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true, comment: "手机号"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeptInfoID = table.Column<int>(type: "int", nullable: true),
                    DepartmentEntityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_UserInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Base_UserInfo_Base_Department_DepartmentEntityID",
                        column: x => x.DepartmentEntityID,
                        principalTable: "Base_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Base_UserInfo_Base_Department_DeptInfoID",
                        column: x => x.DeptInfoID,
                        principalTable: "Base_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "用户信息表");

            migrationBuilder.CreateTable(
                name: "User_ConsumeEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "消费名称"),
                    Amount = table.Column<decimal>(type: "decimal(8,2)", nullable: false, comment: "金额"),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "消费地点"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    Classify = table.Column<int>(type: "int", nullable: false, comment: "分类"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "消费时间"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_ConsumeEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_ConsumeEntity_Base_UserInfo_UserID",
                        column: x => x.UserID,
                        principalTable: "Base_UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "消费支出明细表");

            migrationBuilder.CreateIndex(
                name: "Index_ID",
                table: "Base_Department",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "Index_Account",
                table: "Base_UserInfo",
                column: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Base_UserInfo_Account",
                table: "Base_UserInfo",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Base_UserInfo_DepartmentEntityID",
                table: "Base_UserInfo",
                column: "DepartmentEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Base_UserInfo_DeptInfoID",
                table: "Base_UserInfo",
                column: "DeptInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Base_UserInfo_UserName",
                table: "Base_UserInfo",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_ID1",
                table: "User_ConsumeEntity",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ConsumeEntity_UserID",
                table: "User_ConsumeEntity",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_ConsumeEntity");

            migrationBuilder.DropTable(
                name: "Base_UserInfo");

            migrationBuilder.DropTable(
                name: "Base_Department");
        }
    }
}