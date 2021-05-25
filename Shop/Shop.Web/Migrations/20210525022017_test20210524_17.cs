using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class test20210524_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PartMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InventTrans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartMasterId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventTrans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventTrans_PartMaster_PartMasterId",
                        column: x => x.PartMasterId,
                        principalTable: "PartMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventTrans_PartMasterId",
                table: "InventTrans",
                column: "PartMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventTrans");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PartMaster");
        }
    }
}
