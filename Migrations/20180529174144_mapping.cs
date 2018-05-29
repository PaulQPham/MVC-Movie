using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieTitle",
                table: "MovieRole",
                newName: "Movie");

            migrationBuilder.RenameColumn(
                name: "ActorName",
                table: "MovieRole",
                newName: "Actor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movie",
                table: "MovieRole",
                newName: "MovieTitle");

            migrationBuilder.RenameColumn(
                name: "Actor",
                table: "MovieRole",
                newName: "ActorName");
        }
    }
}
