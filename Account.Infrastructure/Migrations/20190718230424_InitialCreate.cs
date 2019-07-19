using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    AgencyNumber = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    Bloqued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    AccountIDfrom = table.Column<Guid>(nullable: false),
                    AccountIDto = table.Column<Guid>(nullable: false),
                    value = table.Column<decimal>(nullable: false),
                    TypeTransaction = table.Column<int>(nullable: false),
                    TypePay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntities");

            migrationBuilder.DropTable(
                name: "ClientEntities");

            migrationBuilder.DropTable(
                name: "TransferEntities");
        }
    }
}
