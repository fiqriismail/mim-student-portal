using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIM.Portal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmailIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "asp_net_users");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "asp_net_users",
                column: "normalized_email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "asp_net_users");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "asp_net_users",
                column: "normalized_email");
        }
    }
}
