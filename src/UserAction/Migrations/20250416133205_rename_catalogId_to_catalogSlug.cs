using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAction.Migrations
{
    /// <inheritdoc />
    public partial class rename_catalogId_to_catalogSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "UserActionHistory");

            migrationBuilder.AddColumn<string>(
                name: "CatalogSlug",
                table: "UserActionHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatalogSlug",
                table: "UserActionHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "CatalogId",
                table: "UserActionHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
