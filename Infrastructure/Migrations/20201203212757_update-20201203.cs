using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class update20201203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumedTime",
                schema: "public",
                table: "PersistedGrants",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "public",
                table: "PersistedGrants",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                schema: "public",
                table: "PersistedGrants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "public",
                table: "DeviceCodes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                schema: "public",
                table: "DeviceCodes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "public",
                table: "Customers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedOn",
                schema: "public",
                table: "Customers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "public",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "public",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ApplicationUserId",
                schema: "public",
                table: "AspNetRoles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ApplicationUserId",
                schema: "public",
                table: "AspNetRoles",
                column: "ApplicationUserId",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ApplicationUserId",
                schema: "public",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "public",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_ApplicationUserId",
                schema: "public",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ConsumedTime",
                schema: "public",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "public",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "public",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "public",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "public",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastChangedOn",
                schema: "public",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "public",
                table: "AspNetRoles");
        }
    }
}
