using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_Name",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_Title",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "Actor",
                table: "MovieRole");

            migrationBuilder.DropColumn(
                name: "Movie",
                table: "MovieRole");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "MovieRole",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MovieRole",
                newName: "ActorID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRole_Title",
                table: "MovieRole",
                newName: "IX_MovieRole_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRole_Name",
                table: "MovieRole",
                newName: "IX_MovieRole_ActorID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Actor_ActorID",
                table: "MovieRole",
                column: "ActorID",
                principalTable: "Actor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRole_Movie_MovieID",
                table: "MovieRole",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Actor_ActorID",
                table: "MovieRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRole_Movie_MovieID",
                table: "MovieRole");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "MovieRole",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ActorID",
                table: "MovieRole",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRole_MovieID",
                table: "MovieRole",
                newName: "IX_MovieRole_Title");

            migrationBuilder.RenameIndex(
                name: "IX_MovieRole_ActorID",
                table: "MovieRole",
                newName: "IX_MovieRole_Name");

            migrationBuilder.AddColumn<string>(
                name: "Actor",
                table: "MovieRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie",
                table: "MovieRole",
                nullable: true);

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
    }
}
