using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationD.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVacationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VacationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vacation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserVacation",
                columns: table => new
                {
                    Usersid = table.Column<int>(type: "int", nullable: false),
                    Vacationsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVacation", x => new { x.Usersid, x.Vacationsid });
                    table.ForeignKey(
                        name: "FK_UserVacation_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVacation_Vacation_Vacationsid",
                        column: x => x.Vacationsid,
                        principalTable: "Vacation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVacation_Vacationsid",
                table: "UserVacation",
                column: "Vacationsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVacation");

            migrationBuilder.DropTable(
                name: "Vacation");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Users");
        }
    }
}
