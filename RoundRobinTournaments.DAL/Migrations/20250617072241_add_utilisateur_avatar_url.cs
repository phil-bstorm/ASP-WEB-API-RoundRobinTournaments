using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundRobinTournaments.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_utilisateur_avatar_url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avatar_url",
                table: "Utilisateur",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar_url",
                table: "Utilisateur");
        }
    }
}
