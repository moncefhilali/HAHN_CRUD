using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HAHN.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Date", "Description", "Status" },
                values: new object[,]
                {
                    { 1000, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Help with Login", 0 },
                    { 1002, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Promotion code issued", 1 },
                    { 1003, new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Additional user account", 1 },
                    { 1004, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Change payment method", 1 },
                    { 1005, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activate account", 0 },
                    { 1007, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great job", 0 },
                    { 1008, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Great Job", 0 },
                    { 1024, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Happy Customer", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1024);
        }
    }
}
