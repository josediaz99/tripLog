using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tripLog.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "AccommodationId", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, "sampleEmail@gmail.com", "123-456-7890" },
                    { 2, "sampleEmail1@gmail.com", "987-654-3210" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 1, "Sightseeing" },
                    { 2, "Museum Visit" },
                    { 3, "Food Tasting" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "Name" },
                values: new object[,]
                {
                    { 1, "Paris" },
                    { 2, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "AccommodationId", "DestinationId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TripActivity",
                columns: new[] { "ActivityId", "TripId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripActivity",
                keyColumns: new[] { "ActivityId", "TripId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TripActivity",
                keyColumns: new[] { "ActivityId", "TripId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TripActivity",
                keyColumns: new[] { "ActivityId", "TripId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TripActivity",
                keyColumns: new[] { "ActivityId", "TripId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 2);
        }
    }
}
