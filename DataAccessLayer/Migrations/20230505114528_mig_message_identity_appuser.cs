using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_message_identity_appuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages2_ReceiverID",
                table: "Messages2",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages2_SenderID",
                table: "Messages2",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_AspNetUsers_ReceiverID",
                table: "Messages2",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_AspNetUsers_SenderID",
                table: "Messages2",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_AspNetUsers_ReceiverID",
                table: "Messages2");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_AspNetUsers_SenderID",
                table: "Messages2");

            migrationBuilder.DropIndex(
                name: "IX_Messages2_ReceiverID",
                table: "Messages2");

            migrationBuilder.DropIndex(
                name: "IX_Messages2_SenderID",
                table: "Messages2");
        }
    }
}
