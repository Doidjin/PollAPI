using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    poll_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    poll_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.poll_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
