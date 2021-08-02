using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    public partial class DeleteChatsFromChatType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_chat_types_chat_type_id",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_user_chat_chats_id",
                table: "chat_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_chat",
                table: "chat");

            migrationBuilder.RenameTable(
                name: "chat",
                newName: "chats");

            migrationBuilder.RenameIndex(
                name: "ix_chat_chat_type_id",
                table: "chats",
                newName: "ix_chats_chat_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_chats",
                table: "chats",
                column: "id");

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(2412), new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(2425) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3519), new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3521) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3524), new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3526), new DateTime(2021, 8, 2, 19, 40, 50, 48, DateTimeKind.Utc).AddTicks(3527) });

            migrationBuilder.AddForeignKey(
                name: "FK_chat_user_chats_chats_id",
                table: "chat_user",
                column: "chats_id",
                principalTable: "chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chats_chat_types_chat_type_id",
                table: "chats",
                column: "chat_type_id",
                principalTable: "chat_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_user_chats_chats_id",
                table: "chat_user");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_chat_types_chat_type_id",
                table: "chats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_chats",
                table: "chats");

            migrationBuilder.RenameTable(
                name: "chats",
                newName: "chat");

            migrationBuilder.RenameIndex(
                name: "ix_chats_chat_type_id",
                table: "chat",
                newName: "ix_chat_chat_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_chat",
                table: "chat",
                column: "id");

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(4053), new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6205), new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6214), new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6219), new DateTime(2021, 8, 1, 20, 48, 7, 637, DateTimeKind.Utc).AddTicks(6221) });

            migrationBuilder.AddForeignKey(
                name: "FK_chat_chat_types_chat_type_id",
                table: "chat",
                column: "chat_type_id",
                principalTable: "chat_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_user_chat_chats_id",
                table: "chat_user",
                column: "chats_id",
                principalTable: "chat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
