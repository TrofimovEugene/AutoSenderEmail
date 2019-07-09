using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoSenderEmail.Migrations
{
    public partial class IDtemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_template",
                table: "Client",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_template",
                table: "Client");
        }
    }
}
