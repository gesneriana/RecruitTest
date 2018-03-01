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
                name: "recruit_user",
                columns: table => new
                {
                    uuid = table.Column<string>(maxLength: 60, nullable: false),
                    addtime = table.Column<DateTime>(nullable: false),
                    auth_role = table.Column<string>(maxLength: 50, nullable: true),
                    birthday = table.Column<string>(maxLength: 14, nullable: true),
                    company_address = table.Column<string>(maxLength: 200, nullable: true),
                    company_code = table.Column<string>(maxLength: 50, nullable: true),
                    company_contact = table.Column<string>(maxLength: 50, nullable: true),
                    company_name = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    nickname = table.Column<string>(maxLength: 20, nullable: false),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    pwd = table.Column<string>(maxLength: 200, nullable: false),
                    uname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recruit_user", x => x.uuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recruit_user");
        }
    }
}
