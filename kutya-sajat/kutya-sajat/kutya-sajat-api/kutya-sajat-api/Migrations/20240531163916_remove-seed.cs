using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kutya_sajat_api.Migrations
{
    public partial class removeseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "MedicalRecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "MedicalRecordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "MedicalRecordId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "BreedId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MedicalRecords",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MedicalRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "BreedId", "Description", "Name" },
                values: new object[] { 1, "Blanditiis vero sit molestiae accusamus velit necessitatibus.", "Miller" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "IdCardNumber", "Name" },
                values: new object[] { 1, "b0a67ddc-6805-4cd4-8c86-fe0b2e3299c8", "Bertram Steuber" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "BreedId", "DateOfBirth", "Name", "OwnerId" },
                values: new object[] { 1, 1, new DateTime(2012, 1, 3, 14, 48, 13, 893, DateTimeKind.Unspecified).AddTicks(3536), "Whitney", 1 });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "MedicalRecordId", "AnimalId", "CreatedAt", "Description" },
                values: new object[] { 1, 1, new DateTime(1964, 11, 19, 20, 58, 28, 458, DateTimeKind.Unspecified).AddTicks(8700), "aspernatur" });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "MedicalRecordId", "AnimalId", "CreatedAt", "Description" },
                values: new object[] { 2, 1, new DateTime(1968, 8, 10, 1, 47, 23, 97, DateTimeKind.Unspecified).AddTicks(1080), "Error quae qui aliquid iure laborum velit ea aliquam." });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "MedicalRecordId", "AnimalId", "CreatedAt", "Description" },
                values: new object[] { 3, 1, new DateTime(1905, 1, 16, 13, 33, 39, 359, DateTimeKind.Unspecified).AddTicks(6358), "In facere quidem vitae. Est dicta quis quia voluptas provident temporibus quod itaque. Ex laborum officiis nemo totam. Velit praesentium fugiat. Aliquam alias corrupti." });
        }
    }
}
