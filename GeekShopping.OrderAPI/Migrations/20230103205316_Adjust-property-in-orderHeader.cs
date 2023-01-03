using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.OrderAPI.Migrations
{
    public partial class AdjustpropertyinorderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiryMonthYear",
                table: "order_header",
                newName: "ExpiryMothYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiryMothYear",
                table: "order_header",
                newName: "ExpiryMonthYear");
        }
    }
}
