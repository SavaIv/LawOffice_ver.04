using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawOffice.Infrastructure.Migrations
{
    public partial class AddFeedBackFieldInOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "Orders");
        }
    }
}
