using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "logo",
                table: "Templates",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "sub",
                table: "Templates",
                newName: "SubHearderTextsize");

            migrationBuilder.RenameColumn(
                name: "main",
                table: "Templates",
                newName: "SocialMedia");

            migrationBuilder.RenameColumn(
                name: "herotext",
                table: "Templates",
                newName: "MainHearderTextSize");

            migrationBuilder.RenameColumn(
                name: "heroSub",
                table: "Templates",
                newName: "HeroMainSubHearderText");

            migrationBuilder.RenameColumn(
                name: "SMedia",
                table: "Templates",
                newName: "HeroMainHearderText");

            migrationBuilder.RenameColumn(
                name: "Ftext",
                table: "Templates",
                newName: "HeroImage");

            migrationBuilder.RenameColumn(
                name: "BgImg",
                table: "Templates",
                newName: "FooterTextHearder");

            migrationBuilder.CreateTable(
                name: "TemplateDefaults",
                columns: table => new
                {
                    TemplateDefaultId = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateCategory = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_TemplateDefaults", x => x.TemplateDefaultId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateDefaults");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Templates",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "SubHearderTextsize",
                table: "Templates",
                newName: "sub");

            migrationBuilder.RenameColumn(
                name: "SocialMedia",
                table: "Templates",
                newName: "main");

            migrationBuilder.RenameColumn(
                name: "MainHearderTextSize",
                table: "Templates",
                newName: "herotext");

            migrationBuilder.RenameColumn(
                name: "HeroMainSubHearderText",
                table: "Templates",
                newName: "heroSub");

            migrationBuilder.RenameColumn(
                name: "HeroMainHearderText",
                table: "Templates",
                newName: "SMedia");

            migrationBuilder.RenameColumn(
                name: "HeroImage",
                table: "Templates",
                newName: "Ftext");

            migrationBuilder.RenameColumn(
                name: "FooterTextHearder",
                table: "Templates",
                newName: "BgImg");
        }
    }
}
