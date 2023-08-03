using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.portfolio2.web.Migrations
{
    public partial class add_user_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "UserProfile");
        }
    }
}
