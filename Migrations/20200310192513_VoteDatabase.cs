using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolApi.Migrations
{
    public partial class VoteDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    option_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.option_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
