using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndPoints.Migrations
{
    /// <inheritdoc />
    public partial class categoryandcaseupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Items",
                newName: "imageName");

            migrationBuilder.RenameColumn(
                name: "ImageDirectory",
                table: "Items",
                newName: "imageDirectory");

            migrationBuilder.RenameColumn(
                name: "EstimatedValue",
                table: "Items",
                newName: "estimatedValue");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Items",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "imageName",
                table: "Items",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "imageDirectory",
                table: "Items",
                newName: "ImageDirectory");

            migrationBuilder.RenameColumn(
                name: "estimatedValue",
                table: "Items",
                newName: "EstimatedValue");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Items",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
