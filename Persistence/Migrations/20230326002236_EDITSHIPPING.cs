using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EDITSHIPPING : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipingDetails",
                table: "ShipingDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingDetailsId",
                table: "ShipingDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShippindDetailsId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipingDetails",
                table: "ShipingDetails",
                column: "ShippingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipingDetails_StoreId",
                table: "ShipingDetails",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipingDetails",
                table: "ShipingDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShipingDetails_StoreId",
                table: "ShipingDetails");

            migrationBuilder.DropColumn(
                name: "ShippingDetailsId",
                table: "ShipingDetails");

            migrationBuilder.DropColumn(
                name: "ShippindDetailsId",
                table: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipingDetails",
                table: "ShipingDetails",
                columns: new[] { "StoreId", "CustomerId" });
        }
    }
}
