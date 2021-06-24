using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp_Project.Migrations
{
    public partial class C_ProjectDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fullname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    roleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_table", x => x.id);
                    table.ForeignKey(
                        name: "FK__user_tabl__roleI__2B3F6F97",
                        column: x => x.roleId,
                        principalTable: "role_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "news_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    thumbnail = table.Column<string>(type: "text", nullable: false),
                    shortDescription = table.Column<string>(type: "text", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    categoryId = table.Column<long>(type: "bigint", nullable: false),
                    createBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_table", x => x.id);
                    table.ForeignKey(
                        name: "FK__news_tabl__categ__2E1BDC42",
                        column: x => x.categoryId,
                        principalTable: "category_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__news_tabl__creat__2F10007B",
                        column: x => x.createBy,
                        principalTable: "user_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "text", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    createBy = table.Column<long>(type: "bigint", nullable: false),
                    newsId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_table", x => x.id);
                    table.ForeignKey(
                        name: "FK__comment_t__creat__31EC6D26",
                        column: x => x.createBy,
                        principalTable: "user_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__comment_t__newsI__32E0915F",
                        column: x => x.newsId,
                        principalTable: "news_table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__category__357D4CF98E97379F",
                table: "category_table",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comment_table_createBy",
                table: "comment_table",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "IX_comment_table_newsId",
                table: "comment_table",
                column: "newsId");

            migrationBuilder.CreateIndex(
                name: "IX_news_table_categoryId",
                table: "news_table",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_news_table_createBy",
                table: "news_table",
                column: "createBy");

            migrationBuilder.CreateIndex(
                name: "UQ__role_tab__357D4CF9E303D637",
                table: "role_table",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_table_roleId",
                table: "user_table",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "UQ__user_tab__F3DBC5720A716196",
                table: "user_table",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_table");

            migrationBuilder.DropTable(
                name: "news_table");

            migrationBuilder.DropTable(
                name: "category_table");

            migrationBuilder.DropTable(
                name: "user_table");

            migrationBuilder.DropTable(
                name: "role_table");
        }
    }
}
