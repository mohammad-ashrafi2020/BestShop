using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.EF.Migrations
{
    public partial class init_sho_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Slug = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    MetaValue_Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MetaValue_KeyWords = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MetaValue_Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ShowInMenu = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    PersianName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaValue_Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MetaValue_KeyWords = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MetaValue_Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    BitMapImageName = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryAttributes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Hint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryAttributes_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryAttributes_ProductCategoryAttributes_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "ProductCategoryAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                schema: "dbo",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_Slug",
                schema: "dbo",
                table: "ProductCategories",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryAttributes_CategoryId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryAttributes_ParentId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryAttributes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");
        }
    }
}
