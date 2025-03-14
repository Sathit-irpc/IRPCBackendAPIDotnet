using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 17, 21, 46, 917, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "IsDeleted", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 12, 17, 21, 47, 103, DateTimeKind.Utc).AddTicks(5120), "admin@irpcbom.com", "System Administrator", true, false, "$2a$11$hsaQ9LdxkNVom4nhxf8ewOfnck9KCbQXvnVSYGzvjsABlUMJycGMK", null, null, "Admin", null, "admin" },
                    { 2, new DateTime(2025, 3, 12, 17, 21, 47, 290, DateTimeKind.Utc).AddTicks(4910), "manager@irpcbom.com", "System Manager", true, false, "$2a$11$WviNp8zUU67s3eiR7RnHCuPms/Q.2zsL9OzKuZt1mTnW0U3WcL23O", null, null, "Manager", null, "manager" },
                    { 3, new DateTime(2025, 3, 12, 17, 21, 47, 474, DateTimeKind.Utc).AddTicks(7720), "user@irpcbom.com", "Normal User", true, false, "$2a$11$CjD4RAxGTnaMN05tCmDZTuw7Q9RAez2oYiqzZ5xU.19aycHulu7S.", null, null, "User", null, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430));
        }
    }
}
