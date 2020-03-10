using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolApi.Migrations
{
    public partial class ViewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    poll_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.poll_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Views");
        }
    }
}
