using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingBackend.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityTravelAllowance = table.Column<int>(type: "int", nullable: true),
                    RateTravelAllowance = table.Column<double>(type: "float", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "(getutcdate())"),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
