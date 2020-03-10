using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolApi.Migrations
{
    public partial class OptionDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    option_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    option_description = table.Column<string>(nullable: true),
                    poll_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.option_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");
        }
    }
}
