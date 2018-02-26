using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RecruitWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecruitUser",
                columns: table => new
                {
                    uuid = table.Column<string>(nullable: false),
                    CompanyAddress = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyContact = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    addtime = table.Column<DateTime>(nullable: false),
                    cardno = table.Column<string>(maxLength: 14, nullable: true),
                    email = table.Column<string>(nullable: true),
                    nickname = table.Column<string>(maxLength: 20, nullable: false),
                    phone = table.Column<string>(nullable: true),
                    pwd = table.Column<string>(maxLength: 200, nullable: false),
                    role = table.Column<string>(nullable: true),
                    uname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitUser", x => x.uuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruitUser");
        }
    }
}
