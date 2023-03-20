using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Stores_StoreId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "TemplateDefaults");

            migrationBuilder.DropIndex(
                name: "IX_Templates_StoreId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Templates");

            migrationBuilder.AddColumn<string>(
                name: "TemplateCategory",
                table: "Templates",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainHearderTextSize = table.Column<string>(type: "text", nullable: true),
                    SubHearderTextsize = table.Column<string>(type: "text", nullable: true),
                    HeroImage = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    HeroMainHearderText = table.Column<string>(type: "text", nullable: true),
                    HeroMainSubHearderText = table.Column<string>(type: "text", nullable: true),
                    FooterTextHearder = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_Pages_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PageId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    TemplateId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_StoreId",
                table: "Pages",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PageId",
                table: "Photos",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TemplateId",
                table: "Photos",
                column: "TemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropColumn(
                name: "TemplateCategory",
                table: "Templates");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Templates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TemplateDefaults",
                columns: table => new
                {
                    TemplateDefaultId = table.Column<Guid>(type: "uuid", nullable: false),
                    FooterTextHearder = table.Column<string>(type: "text", nullable: true),
                    HeroImage = table.Column<string>(type: "text", nullable: true),
                    HeroMainHearderText = table.Column<string>(type: "text", nullable: true),
                    HeroMainSubHearderText = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    MainHearderTextSize = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    SubHearderTextsize = table.Column<string>(type: "text", nullable: true),
                    TemplateCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDefaults", x => x.TemplateDefaultId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_StoreId",
                table: "Templates",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Stores_StoreId",
                table: "Templates",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
