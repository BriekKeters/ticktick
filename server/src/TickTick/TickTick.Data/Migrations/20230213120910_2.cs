using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TickTick.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Songs_PlaylistId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_PlaylistId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Performer",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Playlists");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Songs",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Songs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Performer",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PlaylistId",
                table: "Songs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SequenceNumber",
                table: "Songs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_PlaylistId",
                table: "Songs",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_PlaylistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Performer",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Playlists",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Performer",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PlaylistId",
                table: "Playlists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SequenceNumber",
                table: "Playlists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_PlaylistId",
                table: "Playlists",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Songs_PlaylistId",
                table: "Playlists",
                column: "PlaylistId",
                principalTable: "Songs",
                principalColumn: "Id");
        }
    }
}
