using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class alternate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_ActorID",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_MovieID",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_ActorID",
                table: "MovieRole");

            migrationBuilder.DropIndex(
                name: "IX_MovieRole_MovieID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_ActorID",
                table: "MovieRole",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRole_MovieID",
                table: "MovieRole",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Actor_ActorID",
                table: "MovieRole",
                column: "ActorID",
                principalTable: "Actor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_MovieID",
                table: "MovieRole",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
