using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteveTenadjangMS2D4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    DatePeremption = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.Now.AddYears(2))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ID);
                    table.UniqueConstraint("AK_Produits_Code", x => x.Code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
