using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update20221213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateJson",
                schema: "public",
                table: "Templates");

            migrationBuilder.CreateTable(
                name: "SheetTemplates",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetTemplates_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalSchema: "public",
                        principalTable: "Templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RowTemplates",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    SheetTemplateId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RowTemplates_SheetTemplates_SheetTemplateId",
                        column: x => x.SheetTemplateId,
                        principalSchema: "public",
                        principalTable: "SheetTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CellTemplates",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    DataSourceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RowTemplateId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellTemplates_RowTemplates_RowTemplateId",
                        column: x => x.RowTemplateId,
                        principalSchema: "public",
                        principalTable: "RowTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CellTemplates_RowTemplateId",
                schema: "public",
                table: "CellTemplates",
                column: "RowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RowTemplates_SheetTemplateId",
                schema: "public",
                table: "RowTemplates",
                column: "SheetTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetTemplates_TemplateId",
                schema: "public",
                table: "SheetTemplates",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellTemplates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RowTemplates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SheetTemplates",
                schema: "public");

            migrationBuilder.AddColumn<string>(
                name: "TemplateJson",
                schema: "public",
                table: "Templates",
                type: "text",
                nullable: true);
        }
    }
}
