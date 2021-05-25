using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class test20210524_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Mechanical",
                newName: "AccountTypeId");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Customer",
                newName: "AccountTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "DocType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mechanical_AccountTypeId",
                table: "Mechanical",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountTypeId",
                table: "Customer",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_DocType_AccountTypeId",
                table: "Customer",
                column: "AccountTypeId",
                principalTable: "DocType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanical_DocType_AccountTypeId",
                table: "Mechanical",
                column: "AccountTypeId",
                principalTable: "DocType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_DocType_AccountTypeId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanical_DocType_AccountTypeId",
                table: "Mechanical");

            migrationBuilder.DropTable(
                name: "DocType");

            migrationBuilder.DropIndex(
                name: "IX_Mechanical_AccountTypeId",
                table: "Mechanical");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AccountTypeId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                table: "Mechanical",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                table: "Customer",
                newName: "AccountType");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
