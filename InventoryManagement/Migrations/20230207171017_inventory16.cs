﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class inventory16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_Users_DispatchedToId",
                table: "Dispatches");

            migrationBuilder.DropForeignKey(
                name: "FK_HsdIndents_Users_OrderedbyId",
                table: "HsdIndents");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_Users_ReturnedbyId",
                table: "Returns");

            migrationBuilder.DropIndex(
                name: "IX_HsdIndents_OrderedbyId",
                table: "HsdIndents");

            migrationBuilder.DropColumn(
                name: "OrderedbyId",
                table: "HsdIndents");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReturnedbyId",
                table: "Returns",
                newName: "ReturnedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Returns_ReturnedbyId",
                table: "Returns",
                newName: "IX_Returns_ReturnedbyUserId");

            migrationBuilder.RenameColumn(
                name: "DispatchedToId",
                table: "Dispatches",
                newName: "DispatchedToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Dispatches_DispatchedToId",
                table: "Dispatches",
                newName: "IX_Dispatches_DispatchedToUserId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "HsdIndents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorBillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenBeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIfscNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_Users_DispatchedToUserId",
                table: "Dispatches",
                column: "DispatchedToUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_Users_ReturnedbyUserId",
                table: "Returns",
                column: "ReturnedbyUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_Users_DispatchedToUserId",
                table: "Dispatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_Users_ReturnedbyUserId",
                table: "Returns");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "HsdIndents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReturnedbyUserId",
                table: "Returns",
                newName: "ReturnedbyId");

            migrationBuilder.RenameIndex(
                name: "IX_Returns_ReturnedbyUserId",
                table: "Returns",
                newName: "IX_Returns_ReturnedbyId");

            migrationBuilder.RenameColumn(
                name: "DispatchedToUserId",
                table: "Dispatches",
                newName: "DispatchedToId");

            migrationBuilder.RenameIndex(
                name: "IX_Dispatches_DispatchedToUserId",
                table: "Dispatches",
                newName: "IX_Dispatches_DispatchedToId");

            migrationBuilder.AddColumn<int>(
                name: "OrderedbyId",
                table: "HsdIndents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HsdIndents_OrderedbyId",
                table: "HsdIndents",
                column: "OrderedbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_Users_DispatchedToId",
                table: "Dispatches",
                column: "DispatchedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HsdIndents_Users_OrderedbyId",
                table: "HsdIndents",
                column: "OrderedbyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_Users_ReturnedbyId",
                table: "Returns",
                column: "ReturnedbyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
