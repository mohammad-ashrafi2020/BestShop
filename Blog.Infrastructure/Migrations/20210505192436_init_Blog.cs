using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class init_Blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BlogPostGroups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    EnglishGroupTitle = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostGroups_BlogPostGroups_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    UrlTitle = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
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
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPostGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPostGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalSchema: "dbo",
                        principalTable: "BlogPostGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostComments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostComments_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_PostId",
                schema: "dbo",
                table: "BlogPostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostGroups_ParentId",
                schema: "dbo",
                table: "BlogPostGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_GroupId",
                schema: "dbo",
                table: "BlogPosts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ShortLink",
                schema: "dbo",
                table: "BlogPosts",
                column: "ShortLink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_SubGroupId",
                schema: "dbo",
                table: "BlogPosts",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UrlTitle",
                schema: "dbo",
                table: "BlogPosts",
                column: "UrlTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostComments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogPostGroups",
                schema: "dbo");
        }
    }
}
