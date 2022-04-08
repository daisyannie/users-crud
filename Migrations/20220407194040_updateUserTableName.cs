using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace users_crud.Migrations
{
    public partial class updateUserTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_user");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateBirth",
                table: "tb_user",
                newName: "date_birth");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tb_user",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_birth",
                table: "Users",
                newName: "DateBirth");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
