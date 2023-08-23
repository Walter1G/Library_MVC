using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcompanyRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Companyies",
                table: "Companyies");

            migrationBuilder.RenameTable(
                name: "Companyies",
                newName: "Companyies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companyies",
                table: "Companyies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Companyies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Tech City", "Tech Solution", "075546564", "122122", "IL", "123 Tech St" },
                    { 2, "viv City", "Vivid Books", "0755468884", "2252122", "IL", "999 Viv St" },
                    { 3, "Lala  City", "Readers Club", "075546564", "99999", "NY", "99 Main St" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Companyies",
                table: "Companyies");

            migrationBuilder.DeleteData(
                table: "Companyies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companyies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companyies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Companyies",
                newName: "Companyies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companyies",
                table: "Companyies",
                column: "Id");
        }
    }
}
