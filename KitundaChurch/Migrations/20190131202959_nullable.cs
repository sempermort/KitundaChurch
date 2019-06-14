using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KitundaChurch.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImageFile_Gallery_GalleryId",
                table: "UserImageFile");

            migrationBuilder.DropIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile");

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "UserImageFile",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "UserImageFile",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImageFile_Gallery_GalleryId",
                table: "UserImageFile",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImageFile_Gallery_GalleryId",
                table: "UserImageFile");

            migrationBuilder.DropIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile");

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "UserImageFile",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "UserImageFile",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImageFile_EventId",
                table: "UserImageFile",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImageFile_Events_EventId",
                table: "UserImageFile",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImageFile_Gallery_GalleryId",
                table: "UserImageFile",
                column: "GalleryId",
                principalTable: "Gallery",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
