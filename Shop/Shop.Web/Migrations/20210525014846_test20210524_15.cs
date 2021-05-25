using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class test20210524_15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "PartMaster",
                newName: "ServiceTypeId");

            migrationBuilder.CreateTable(
                name: "InvoiceHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<decimal>(nullable: false),
                    TotalIVA = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceHeaderId = table.Column<int>(nullable: true),
                    ServiceLineId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_InvoiceHeader_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_ServiceLine_ServiceLineId",
                        column: x => x.ServiceLineId,
                        principalTable: "ServiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartMaster_ServiceTypeId",
                table: "PartMaster",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_CustomerId",
                table: "InvoiceHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceHeaderId",
                table: "InvoiceLines",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ServiceLineId",
                table: "InvoiceLines",
                column: "ServiceLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartMaster_ServiceType_ServiceTypeId",
                table: "PartMaster",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartMaster_ServiceType_ServiceTypeId",
                table: "PartMaster");

            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "InvoiceHeader");

            migrationBuilder.DropIndex(
                name: "IX_PartMaster_ServiceTypeId",
                table: "PartMaster");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "PartMaster",
                newName: "ServiceType");
        }
    }
}
