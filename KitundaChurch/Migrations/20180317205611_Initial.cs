using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KitundaChurch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "ChurchMembers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChurchMembersId = table.Column<int>(type: "int", nullable: false),
                    DarasaSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatoleoId = table.Column<int>(type: "int", nullable: false),
                    MemberShipNo = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    Resident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchMembers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    songId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    songData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    songName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.songId);
                    table.ForeignKey(
                        name: "FK_Songs_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matoleo",
                columns: table => new
                {
                    MatoleoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChurchMembersId = table.Column<int>(type: "int", nullable: false),
                    ChurchMembersName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MpangoKanisa = table.Column<double>(type: "float", nullable: false),
                    Savetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Zaka = table.Column<double>(type: "float", nullable: false),
                    sadakaBk = table.Column<double>(type: "float", nullable: false),
                    sadakaConf = table.Column<double>(type: "float", nullable: false),
                    sadakaMajengo = table.Column<double>(type: "float", nullable: false),
                    sadakaMakambi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matoleo", x => x.MatoleoId);
                    table.ForeignKey(
                        name: "FK_Matoleo_ChurchMembers_ChurchMembersName",
                        column: x => x.ChurchMembersName,
                        principalTable: "ChurchMembers",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mengineyo",
                columns: table => new
                {
                    MengineyoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MatoleoId = table.Column<int>(type: "int", nullable: false),
                    descr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mengineyo", x => x.MengineyoId);
                    table.ForeignKey(
                        name: "FK_Mengineyo_Matoleo_MatoleoId",
                        column: x => x.MatoleoId,
                        principalTable: "Matoleo",
                        principalColumn: "MatoleoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matoleo_ChurchMembersName",
                table: "Matoleo",
                column: "ChurchMembersName");

            migrationBuilder.CreateIndex(
                name: "IX_Mengineyo_MatoleoId",
                table: "Mengineyo",
                column: "MatoleoId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mengineyo");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Matoleo");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "ChurchMembers");
        }
    }
}
