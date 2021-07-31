using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    public partial class CreateChatTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chat_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    alias = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_types", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "chat_types",
                columns: new[] { "id", "alias", "created_date", "updated_date" },
                values: new object[,]
                {
                    { 1, "Private", new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(3689), new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(3705) },
                    { 2, "Group", new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6173), new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6181) },
                    { 3, "Channel", new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6187), new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6189) },
                    { 4, "Supergroup", new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6193), new DateTime(2021, 7, 31, 21, 59, 45, 64, DateTimeKind.Utc).AddTicks(6194) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_types");
        }
    }
}
