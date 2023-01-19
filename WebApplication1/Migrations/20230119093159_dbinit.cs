using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCitie",
                columns: table => new
                {
                    Cityid = table.Column<int>(name: "City_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cityname = table.Column<string>(name: "City_name", type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCitie", x => x.Cityid);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    Customerid = table.Column<int>(name: "Customer_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customername = table.Column<string>(name: "Customer_name", type: "nvarchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cityid = table.Column<int>(name: "City_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.Customerid);
                    table.ForeignKey(
                        name: "FK_tblCustomers_tblCitie_City_id",
                        column: x => x.Cityid,
                        principalTable: "tblCitie",
                        principalColumn: "City_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomers_City_id",
                table: "tblCustomers",
                column: "City_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "tblCitie");
        }
    }
}
