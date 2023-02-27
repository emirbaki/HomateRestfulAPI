using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homate.Migrations
{
    public partial class shopMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Leziz Ev Yemekleri için iyi bir başlangıç", "Hanife'nin Mekanı" },
                    { 2, "Çiğköftemiz kötü ama bir sürü sos ve ekstra içerik veriyoruz.", "Komagene Çiğköfte" },
                    { 3, "Acıkmayın", "Burgerye Ulan" },
                    { 4, "Beyaz toz harici her türlü sakatat bulunur.", "Koko Faruk" },
                    { 5, "Bildiğin Arby's", "Arby's" },
                    { 6, "Dünyanın en sıcak pizzası", "Kopernik Pizza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
