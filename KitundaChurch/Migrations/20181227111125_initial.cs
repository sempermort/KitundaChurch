using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KitundaChurch.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "ChurchMembers",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ChurchMembersId = table.Column<int>(nullable: false),
                    DarasaSS = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    MatoleoId = table.Column<int>(nullable: false),
                    MemberShipNo = table.Column<int>(nullable: false),
                    PhoneNo = table.Column<int>(nullable: false),
                    Resident = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Zone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchMembers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    contentual = table.Column<string>(nullable: true),
                    place = table.Column<string>(nullable: true),
                    timer = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    images = table.Column<byte>(nullable: false),
                    time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    songId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumId = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    songData = table.Column<byte[]>(nullable: true),
                    songName = table.Column<string>(nullable: true)
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
                    MatoleoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChurchMembersId = table.Column<int>(nullable: false),
                    ChurchMembersName = table.Column<string>(nullable: true),
                    MpangoKanisa = table.Column<double>(nullable: false),
                    Savetime = table.Column<DateTime>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Zaka = table.Column<double>(nullable: false),
                    sadakaBk = table.Column<double>(nullable: false),
                    sadakaConf = table.Column<double>(nullable: false),
                    sadakaMajengo = table.Column<double>(nullable: false),
                    sadakaMakambi = table.Column<double>(nullable: false)
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
                name: "Matumizi",
                columns: table => new
                {
                    MatumiziId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    FormNo = table.Column<int>(nullable: false),
                    Receiver = table.Column<string>(nullable: true),
                    Usedfor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matumizi", x => x.MatumiziId);
                    table.ForeignKey(
                        name: "FK_Matumizi_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserImageFile",
                columns: table => new
                {
                    UserImageFileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    GalleryId = table.Column<int>(nullable: false),
                    content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImageFile", x => x.UserImageFileId);
                    table.ForeignKey(
                        name: "FK_UserImageFile_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserImageFile_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CName = table.Column<string>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mengineyo",
                columns: table => new
                {
                    MengineyoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    MatoleoId = table.Column<int>(nullable: false),
                    descr = table.Column<string>(nullable: true)
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
                name: "IX_Category_NewsId",
                table: "Category",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Matoleo_ChurchMembersName",
                table: "Matoleo",
                column: "ChurchMembersName");

            migrationBuilder.CreateIndex(
                name: "IX_Matumizi_DepartmentId",
                table: "Matumizi",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mengineyo_MatoleoId",
                table: "Mengineyo",
                column: "MatoleoId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImageFile_GalleryId",
                table: "UserImageFile",
                column: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Matumizi");

            migrationBuilder.DropTable(
                name: "Mengineyo");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "UserImageFile");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Matoleo");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "ChurchMembers");
        }
    }
}
