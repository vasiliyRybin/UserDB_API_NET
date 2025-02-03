using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDB_API_NET.Migrations
{
    /// <inheritdoc />
    public partial class AddedKeyAttribute_TaxID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    TaxID = table.Column<long>(type: "INTEGER", nullable: true),
                    PassNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_PassNumber",
                table: "Users",
                column: "PassNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TaxID",
                table: "Users",
                column: "TaxID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
