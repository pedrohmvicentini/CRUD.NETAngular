using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PersonContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_PersonId",
                table: "Contact",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Person_PersonId",
                table: "Contact",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Person_PersonId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_PersonId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Contact");
        }
    }
}
