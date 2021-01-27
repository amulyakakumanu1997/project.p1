using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerEntityId = table.Column<long>(type: "bigint", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customer",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Store",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Order",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.APizzaModelEntityId);
                    table.ForeignKey(
                        name: "FK_Crust_Pizza_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "Pizza",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.APizzaModelEntityId);
                    table.ForeignKey(
                        name: "FK_Size_Pizza_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "Pizza",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APizzaModelEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Topping_Pizza_APizzaModelEntityId",
                        column: x => x.APizzaModelEntityId,
                        principalTable: "Pizza",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "Amulya" },
                    { 2L, "Fred" },
                    { 3L, "Sam" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "EntityId", "Name" },
                values: new object[,]
                {
                    { 1L, "Dominos" },
                    { 2L, "Pizza Hut" },
                    { 3L, "Davannis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerEntityId",
                table: "Order",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityId",
                table: "Order",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderEntityId",
                table: "Pizza",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_APizzaModelEntityId",
                table: "Topping",
                column: "APizzaModelEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
