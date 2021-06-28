using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.EF.Migrations
{
    public partial class fix_brands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                schema: "dbo",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryAttributes_ProductCategories_CategoryId",
                schema: "dbo",
                table: "ProductCategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryAttributes_ProductCategoryAttributes_ParentId",
                schema: "dbo",
                table: "ProductCategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brand_BrandId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoryAttributes",
                schema: "dbo",
                table: "ProductCategoryAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                schema: "dbo",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "ProductCategoryAttributes",
                schema: "dbo",
                newName: "CategoryAttributes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                schema: "dbo",
                newName: "Categories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryAttributes_ParentId",
                schema: "dbo",
                table: "CategoryAttributes",
                newName: "IX_CategoryAttributes_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryAttributes_CategoryId",
                schema: "dbo",
                table: "CategoryAttributes",
                newName: "IX_CategoryAttributes_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_Slug",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ParentId",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Brands",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainImage",
                schema: "dbo",
                table: "Brands",
                type: "nvarchar(110)",
                maxLength: 110,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                schema: "dbo",
                table: "Brands",
                type: "nvarchar(110)",
                maxLength: 110,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttributes",
                schema: "dbo",
                table: "CategoryAttributes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "dbo",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                schema: "dbo",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                schema: "dbo",
                table: "Categories",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributes_Categories_CategoryId",
                schema: "dbo",
                table: "CategoryAttributes",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributes_CategoryAttributes_ParentId",
                schema: "dbo",
                table: "CategoryAttributes",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "dbo",
                table: "Products",
                column: "BrandId",
                principalSchema: "dbo",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributes_Categories_CategoryId",
                schema: "dbo",
                table: "CategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributes_CategoryAttributes_ParentId",
                schema: "dbo",
                table: "CategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttributes",
                schema: "dbo",
                table: "CategoryAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                schema: "dbo",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "CategoryAttributes",
                schema: "dbo",
                newName: "ProductCategoryAttributes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "ProductCategories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "dbo",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributes_ParentId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                newName: "IX_ProductCategoryAttributes_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributes_CategoryId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                newName: "IX_ProductCategoryAttributes_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Slug",
                schema: "dbo",
                table: "ProductCategories",
                newName: "IX_ProductCategories_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                schema: "dbo",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "MainImage",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(110)",
                oldMaxLength: 110,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(110)",
                oldMaxLength: 110,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoryAttributes",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                schema: "dbo",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                schema: "dbo",
                table: "ProductCategories",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryAttributes_ProductCategories_CategoryId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryAttributes_ProductCategoryAttributes_ParentId",
                schema: "dbo",
                table: "ProductCategoryAttributes",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "ProductCategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brand_BrandId",
                schema: "dbo",
                table: "Products",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
