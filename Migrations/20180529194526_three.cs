using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_Actor",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_Movie",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_Actor",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_Movie",
                table: "MovieRole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Movie_Title",
                table: "Movie");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Actor_Name",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "ActorID",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "MovieRole");

            migrationBuilder.AlterColumn<string>(
                name: "Movie",
                table: "MovieRole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actor",
                table: "MovieRole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "MovieRole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Title",
                table: "MovieRole",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actor",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_Name",
                table: "MovieRole",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_Title",
                table: "MovieRole",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Actor_Name",
                table: "MovieRole",
                column: "Name",
                principalTable: "Actor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_Title",
                table: "MovieRole",
                column: "Title",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_Name",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_Title",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_Name",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_Title",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MovieRole");

            migrationBuilder.AlterColumn<string>(
                name: "Movie",
                table: "MovieRole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actor",
                table: "MovieRole",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActorID",
                table: "MovieRole",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "MovieRole",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Movie_Title",
                table: "Movie",
                column: "Title");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Actor_Name",
                table: "Actor",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_Actor",
                table: "MovieRole",
                column: "Actor");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_Movie",
                table: "MovieRole",
                column: "Movie");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Actor_Actor",
                table: "MovieRole",
                column: "Actor",
                principalTable: "Actor",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_Movie",
                table: "MovieRole",
                column: "Movie",
                principalTable: "Movie",
                principalColumn: "Title",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
