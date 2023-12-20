using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerTrackingSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class VeriTurunuGuncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInterests_Customers_CustomerId1",
                table: "CustomerInterests");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInterests_CustomerId1",
                table: "CustomerInterests");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "CustomerInterests");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerInterests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInterests_CustomerId",
                table: "CustomerInterests",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInterests_Customers_CustomerId",
                table: "CustomerInterests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInterests_Customers_CustomerId",
                table: "CustomerInterests");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInterests_CustomerId",
                table: "CustomerInterests");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CustomerInterests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "CustomerInterests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInterests_CustomerId1",
                table: "CustomerInterests",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInterests_Customers_CustomerId1",
                table: "CustomerInterests",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
