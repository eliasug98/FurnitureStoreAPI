using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureStoreProject.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[] { 1, "Muebles grandes de madera.", "muebleGrande", "Muebles de Madera" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[] { 2, "Muebles medianos en oferta", "muebleMediano", "Muebles medianos" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[] { 3, "Muebles pequeños para decoracion", "mueblePequenio", "Muebles pequeños" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UserName" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3129), "usuario1@gmail.com", "has3vgHdhDfbsSajsd", "Admin", "Elias" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UserName" },
                values: new object[] { 2, new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3142), "usuario2@gmail.com", "sdDEasdegR12FgDsnasfdA", "Admin", "Mauri" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UserName" },
                values: new object[] { 3, new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3144), "usuario3@gmail.com", "sdDEasfegR12sgDsnasfdA", "Cliente", "cliente1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "Role", "UserName" },
                values: new object[] { 4, new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3146), "usuario4@gmail.com", "sdDEasqegR12FgDsnasudA", "Cliente", "cliente2" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "UserId" },
                values: new object[] { 1, new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3003), 3 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "UserId" },
                values: new object[] { 2, new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3007), 4 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "UserId" },
                values: new object[] { 3, new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3008), 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, true, 1, "La mesa de madera.", "mesa.svg", "Mesa", 420m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 2, false, 1, "La silla de madera.", "silla.svg", "Silla", 320m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 3, true, 2, "El sillon comodo y lujoso.", "sillon.svg", "Sillon", 520m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 4, false, 2, "El ropero mas grande.", "ropero.svg", "Ropero", 520m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 5, true, 3, "Mesita pequeña con 3 patas.", "mesita.svg", "Mesita pequeña", 520m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 6, false, 3, "La cajonera con espacios divididos.", "cajonera.svg", "Cajonera", 520m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1260m, 1, 3 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 1, 2600m, 3, 5 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 2, 640m, 2, 2 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 4, 2, 520m, 4, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 5, 3, 960m, 2, 3 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 6, 3, 2080m, 4, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
