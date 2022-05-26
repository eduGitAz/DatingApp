using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class completeOrder6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Devices_DeviceId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Devices_DeviceId",
                table: "Orders",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Devices_DeviceId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Devices_DeviceId",
                table: "Orders",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
