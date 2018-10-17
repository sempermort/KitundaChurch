using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KitundaChurch.Migrations
{
    public partial class nuuia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_UserImageFile_ImageUserImageFileId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ImageUserImageFileId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageUserImageFileId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "UserImageFile",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "UserImageFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "UserImageFile",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "content",
                table: "UserImageFile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile");

            migrationBuilder.DropIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "UserImageFile");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "UserImageFile");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "UserImageFile");

            migrationBuilder.DropColumn(
                name: "content",
                table: "UserImageFile");

            migrationBuilder.AddColumn<int>(
                name: "ImageUserImageFileId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageUserImageFileId",
                table: "Events",
                column: "ImageUserImageFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_UserImageFile_ImageUserImageFileId",
                table: "Events",
                column: "ImageUserImageFileId",
                principalTable: "UserImageFile",
                principalColumn: "UserImageFileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
