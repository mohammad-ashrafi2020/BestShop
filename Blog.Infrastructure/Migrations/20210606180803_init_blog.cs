using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class init_blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.CreateTable(
                name: "BlogPostGroups",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    EnglishGroupTitle = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostGroups_BlogPostGroups_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "blog",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Slug = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "varchar(110)", unicode: false, maxLength: 110, nullable: false),
                    ImageAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    ShortLink = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TimeRequiredToStudy = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    SubGroupId = table.Column<long>(type: "bigint", nullable: true),
                    Visit = table.Column<long>(type: "bigint", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPostGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "blog",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPostGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalSchema: "blog",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostGroups_ParentId",
                schema: "blog",
                table: "BlogPostGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_GroupId",
                schema: "blog",
                table: "BlogPosts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ShortLink",
                schema: "blog",
                table: "BlogPosts",
                column: "ShortLink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Slug",
                schema: "blog",
                table: "BlogPosts",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_SubGroupId",
                schema: "blog",
                table: "BlogPosts",
                column: "SubGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "BlogPostGroups",
                schema: "blog");
        }
    }
}
