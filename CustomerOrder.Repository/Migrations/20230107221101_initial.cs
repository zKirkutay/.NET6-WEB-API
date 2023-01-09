using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOrder.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[] { 1, "London BT34FT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elise", "Rick", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[] { 2, "Milton Keynes MK34FT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon", "Bon", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[] { 3, "London SW34FT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrea", "Bon", null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "OrderDate", "OrderNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5641), 1, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5612), 1254, null },
                    { 2, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5644), 1, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5643), 845, null },
                    { 3, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5647), 2, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5646), 365, null },
                    { 4, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5649), 1, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5648), 254, null },
                    { 5, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5651), 2, new DateTime(2023, 1, 7, 22, 11, 1, 179, DateTimeKind.Local).AddTicks(5650), 124, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
