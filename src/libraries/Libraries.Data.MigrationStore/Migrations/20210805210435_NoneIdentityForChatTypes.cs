using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    public partial class NoneIdentityForChatTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_user");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "chat_types");
        }
    }
}
