using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GcoinNode.Migrations
{
    public partial class _102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Blockid",
                table: "TransactionItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlockItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PrevHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockItem", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_Blockid",
                table: "TransactionItem",
                column: "Blockid");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItem_BlockItem_Blockid",
                table: "TransactionItem",
                column: "Blockid",
                principalTable: "BlockItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItem_BlockItem_Blockid",
                table: "TransactionItem");

            migrationBuilder.DropTable(
                name: "BlockItem");

            migrationBuilder.DropIndex(
                name: "IX_TransactionItem_Blockid",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "Blockid",
                table: "TransactionItem");
        }
    }
}
