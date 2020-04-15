using Microsoft.EntityFrameworkCore.Migrations;

namespace NomadWork.Api.Migrations
{
    public partial class ModeV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(6)", nullable: false),
                    Zipcode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    Coutry = table.Column<string>(type: "varchar(30)", nullable: false),
                    State = table.Column<string>(type: "varchar(30)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8,8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(8,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(6)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumberPhone = table.Column<string>(type: "varchar(15)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(40)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AddressId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Establishmment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(6)", nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    AddressId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishmment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establishmment_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Establishmment_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacteristicModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(6)", nullable: false),
                    HasNotHas = table.Column<short>(nullable: false),
                    ServiceOffered = table.Column<short>(nullable: false),
                    ServiceOfferedQuality = table.Column<short>(nullable: false),
                    EstablishmmentModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacteristicModel_Establishmment_EstablishmmentModelId",
                        column: x => x.EstablishmmentModelId,
                        principalTable: "Establishmment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicModel_EstablishmmentModelId",
                table: "CharacteristicModel",
                column: "EstablishmmentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishmment_AddressId",
                table: "Establishmment",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishmment_OwnerId",
                table: "Establishmment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacteristicModel");

            migrationBuilder.DropTable(
                name: "Establishmment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
