using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class ShopMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KeyWords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreationDate", "Description", "KeyWords", "MetaDescription", "Name", "Picture", "PictureAlt", "PictureTitle", "Slug", "Status" },
                values: new object[] { "01H2332JBY835BBXBZ9KTN8AK9", "1402/3/14", "Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
