using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.Web.Migrations
{
    public partial class craeteTableCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherCity",
                columns: table => new
                {
                    WeatherCityID = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    Temperatures = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCity", x => x.WeatherCityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherCity");
        }
    }
}
