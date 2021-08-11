using Microsoft.EntityFrameworkCore.Migrations;

namespace Post.Infrastructure.Persistence.Migrations
{
    public partial class AddPostsToTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_BlogPostId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogPostId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "BlogPostTag",
                columns: table => new
                {
                    BlogPostsId = table.Column<int>(type: "int", nullable: false),
                    BlogTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostTag", x => new { x.BlogPostsId, x.BlogTagsId });
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Posts_BlogPostsId",
                        column: x => x.BlogPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Tags_BlogTagsId",
                        column: x => x.BlogTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_BlogTagsId",
                table: "BlogPostTag",
                column: "BlogTagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostTag");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogPostId",
                table: "Tags",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_BlogPostId",
                table: "Tags",
                column: "BlogPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
