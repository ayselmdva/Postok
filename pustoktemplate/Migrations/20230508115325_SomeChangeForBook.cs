using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pustoktemplate.Migrations
{
    public partial class SomeChangeForBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "İsmain",
                table: "BookImages",
                newName: "Ismain");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BookImages",
                newName: "Image");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Books",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ismain",
                table: "BookImages",
                newName: "İsmain");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "BookImages",
                newName: "Name");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Point",
                table: "Books",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
