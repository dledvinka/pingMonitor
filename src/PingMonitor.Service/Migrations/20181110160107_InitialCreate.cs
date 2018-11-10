using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PingMonitor.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TargetUrl = table.Column<string>(nullable: true),
                    PingTimeoutMs = table.Column<int>(nullable: false),
                    IntervalBetweenPingsMs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PingResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundtripTime = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PingBatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PingResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PingResult_Batches_PingBatchId",
                        column: x => x.PingBatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PingResult_PingBatchId",
                table: "PingResult",
                column: "PingBatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PingResult");

            migrationBuilder.DropTable(
                name: "Batches");
        }
    }
}
