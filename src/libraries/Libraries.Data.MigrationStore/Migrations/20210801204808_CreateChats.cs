using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    public partial class CreateChats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    chat_type_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_chat_types_chat_type_id",
                        column: x => x.chat_type_id,
                        principalTable: "chat_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_user",
                columns: table => new
                {
                    chats_id = table.Column<long>(type: "bigint", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_user", x => new { x.chats_id, x.users_id });
                    table.ForeignKey(
                        name: "FK_chat_user_chat_chats_id",
                        column: x => x.chats_id,
                        principalTable: "chat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chat_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateIndex(
                name: "ix_chat_chat_type_id",
                table: "chat",
                column: "chat_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_chat_user_users_id",
                table: "chat_user",
                column: "users_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_user");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(5871), new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7068), new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7074), new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "chat_types",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7076), new DateTime(2021, 8, 1, 19, 43, 47, 974, DateTimeKind.Utc).AddTicks(7077) });
        }
    }
}
