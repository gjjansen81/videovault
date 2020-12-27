using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class update20201227 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "public",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastChangedOn",
                schema: "public",
                table: "Customers",
                newName: "LastModified");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "public",
                table: "Customers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                schema: "public",
                table: "Customers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "public",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                schema: "public",
                table: "Customers",
                newName: "LastChangedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "public",
                table: "Customers",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
