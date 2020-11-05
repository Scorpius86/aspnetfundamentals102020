using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Fundamentals.Client.Web.Migrations
{
    public partial class RemoveCustomField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomField",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomField",
                table: "Usuario",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true);
        }
    }
}
