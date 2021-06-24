using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp_Project.Migrations
{
    public partial class C_Project_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__comment_t__newsI__32E0915F",
                table: "comment_table");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_table_news_table_newsId",
                table: "comment_table",
                column: "newsId",
                principalTable: "news_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_table_news_table_newsId",
                table: "comment_table");

            migrationBuilder.AddForeignKey(
                name: "FK__comment_t__newsI__32E0915F",
                table: "comment_table",
                column: "newsId",
                principalTable: "news_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
