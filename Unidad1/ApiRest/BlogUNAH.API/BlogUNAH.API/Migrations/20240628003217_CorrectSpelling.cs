using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogUNAH.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrectSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_posts_post_id",
                schema: "dbo",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_tags_tag_id",
                schema: "dbo",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                schema: "dbo",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                schema: "dbo",
                newName: "post_tags",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_tag_id",
                schema: "dbo",
                table: "post_tags",
                newName: "IX_post_tags_tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_post_id",
                schema: "dbo",
                table: "post_tags",
                newName: "IX_post_tags_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_tags",
                schema: "dbo",
                table: "post_tags",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_tags_posts_post_id",
                schema: "dbo",
                table: "post_tags",
                column: "post_id",
                principalSchema: "dbo",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_tags_tags_tag_id",
                schema: "dbo",
                table: "post_tags",
                column: "tag_id",
                principalSchema: "dbo",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_tags_posts_post_id",
                schema: "dbo",
                table: "post_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_post_tags_tags_tag_id",
                schema: "dbo",
                table: "post_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_tags",
                schema: "dbo",
                table: "post_tags");

            migrationBuilder.RenameTable(
                name: "post_tags",
                schema: "dbo",
                newName: "PostTags",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_post_tags_tag_id",
                schema: "dbo",
                table: "PostTags",
                newName: "IX_PostTags_tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_post_tags_post_id",
                schema: "dbo",
                table: "PostTags",
                newName: "IX_PostTags_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                schema: "dbo",
                table: "PostTags",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_posts_post_id",
                schema: "dbo",
                table: "PostTags",
                column: "post_id",
                principalSchema: "dbo",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_tags_tag_id",
                schema: "dbo",
                table: "PostTags",
                column: "tag_id",
                principalSchema: "dbo",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
