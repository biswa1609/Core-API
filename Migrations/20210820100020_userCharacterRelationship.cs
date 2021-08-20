using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_API.Migrations
{
    public partial class userCharacterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CharacterModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswodSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterModels_UserId",
                table: "CharacterModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterModels_User_UserId",
                table: "CharacterModels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterModels_User_UserId",
                table: "CharacterModels");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_CharacterModels_UserId",
                table: "CharacterModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CharacterModels");
        }
    }
}
