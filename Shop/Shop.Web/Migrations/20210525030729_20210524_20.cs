using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class _20210524_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "ServiceHeader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "InvoiceHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "InvoiceHeader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHeader_StoreId",
                table: "ServiceHeader",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_StoreId",
                table: "InvoiceHeader",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeader_Store_StoreId",
                table: "InvoiceHeader",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHeader_Store_StoreId",
                table: "ServiceHeader",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeader_Store_StoreId",
                table: "InvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHeader_Store_StoreId",
                table: "ServiceHeader");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_ServiceHeader_StoreId",
                table: "ServiceHeader");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHeader_StoreId",
                table: "InvoiceHeader");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ServiceHeader");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "InvoiceHeader");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "InvoiceHeader");
        }
    }
}
