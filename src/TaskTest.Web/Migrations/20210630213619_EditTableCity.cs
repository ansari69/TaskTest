using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTest.Web.Migrations
{
    public partial class EditTableCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherCity",
                table: "WeatherCity");

            migrationBuilder.RenameTable(
                name: "WeatherCity",
                newName: "WeatherCitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherCitys",
                table: "WeatherCitys",
                column: "WeatherCityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherCitys",
                table: "WeatherCitys");

            migrationBuilder.RenameTable(
                name: "WeatherCitys",
                newName: "WeatherCity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherCity",
                table: "WeatherCity",
                column: "WeatherCityID");
        }
    }
}
