using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class updateone : Migration
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

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movie",
                newName: "MoviesID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Actor",
                newName: "ActorsID");

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
                name: "ActorsID",
                table: "MovieRole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesID",
                table: "MovieRole",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actor",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_ActorsID",
                table: "MovieRole",
                column: "ActorsID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_MoviesID",
                table: "MovieRole",
                column: "MoviesID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Actor_ActorsID",
                table: "MovieRole",
                column: "ActorsID",
                principalTable: "Actor",
                principalColumn: "ActorsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_MoviesID",
                table: "MovieRole",
                column: "MoviesID",
                principalTable: "Movie",
                principalColumn: "MoviesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_ActorsID",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_MoviesID",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_ActorsID",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_MoviesID",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "ActorsID",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "MoviesID",
                table: "MovieRole");

            migrationBuilder.RenameColumn(
                name: "MoviesID",
                table: "Movie",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ActorsID",
                table: "Actor",
                newName: "ID");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_Movie",
                table: "MovieRole",
                column: "Movie",
                principalTable: "Movie",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
