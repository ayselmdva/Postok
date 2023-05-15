using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pustoktemplate.Migrations
{
    public partial class addrateandismjain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "İsmain",
                table: "BookImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "İsmain",
                table: "BookImages");
        }
    }
}
