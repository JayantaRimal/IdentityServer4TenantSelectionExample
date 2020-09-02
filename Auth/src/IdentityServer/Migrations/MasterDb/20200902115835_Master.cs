using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations.MasterDb
{
    public partial class Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DatabaseName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "DatabaseName", "EndDate", "StartDate", "UserId" },
                values: new object[] { 1L, "jayanta", "JayantaDatabase", new DateTime(2020, 9, 2, 17, 43, 34, 579, DateTimeKind.Local).AddTicks(2954), new DateTime(2020, 9, 2, 17, 43, 34, 577, DateTimeKind.Local).AddTicks(6959), "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
