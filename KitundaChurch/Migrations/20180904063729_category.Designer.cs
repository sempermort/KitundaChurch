﻿// <auto-generated />
using KitundaChurch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace KitundaChurch.Migrations
{
    [DbContext(typeof(KitundaChurchContext))]
    [Migration("20180904063729_category")]
    partial class category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KitundaChurch.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("AlbumId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("KitundaChurch.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CName");

                    b.Property<int?>("NewsId");

                    b.HasKey("CategoryId");

                    b.HasIndex("NewsId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("KitundaChurch.Models.ChurchMembers", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChurchMembersId");

                    b.Property<string>("DarasaSS");

                    b.Property<string>("FamilyName");

                    b.Property<string>("MaritalStatus");

                    b.Property<int>("MatoleoId");

                    b.Property<int>("MemberShipNo");

                    b.Property<int>("PhoneNo");

                    b.Property<string>("Resident");

                    b.Property<string>("Status");

                    b.Property<string>("Zone");

                    b.HasKey("Name");

                    b.ToTable("ChurchMembers");
                });

            modelBuilder.Entity("KitundaChurch.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Total");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("KitundaChurch.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("contentual");

                    b.Property<string>("place");

                    b.Property<DateTime>("timer");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("KitundaChurch.Models.Matoleo", b =>
                {
                    b.Property<int>("MatoleoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChurchMembersId");

                    b.Property<string>("ChurchMembersName");

                    b.Property<double>("MpangoKanisa");

                    b.Property<DateTime>("Savetime");

                    b.Property<int>("Total");

                    b.Property<double>("Zaka");

                    b.Property<double>("sadakaBk");

                    b.Property<double>("sadakaConf");

                    b.Property<double>("sadakaMajengo");

                    b.Property<double>("sadakaMakambi");

                    b.HasKey("MatoleoId");

                    b.HasIndex("ChurchMembersName");

                    b.ToTable("Matoleo");
                });

            modelBuilder.Entity("KitundaChurch.Models.Matumizi", b =>
                {
                    b.Property<int>("MatumiziId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("FormNo");

                    b.Property<string>("Receiver");

                    b.Property<string>("Usedfor");

                    b.HasKey("MatumiziId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Matumizi");
                });

            modelBuilder.Entity("KitundaChurch.Models.Mengineyo", b =>
                {
                    b.Property<int>("MengineyoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("MatoleoId");

                    b.Property<string>("descr");

                    b.HasKey("MengineyoId");

                    b.HasIndex("MatoleoId");

                    b.ToTable("Mengineyo");
                });

            modelBuilder.Entity("KitundaChurch.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("content");

                    b.Property<byte>("images");

                    b.Property<DateTime?>("time");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("KitundaChurch.Models.Song", b =>
                {
                    b.Property<int>("songId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<string>("ContentType");

                    b.Property<byte[]>("songData");

                    b.Property<string>("songName");

                    b.HasKey("songId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("KitundaChurch.Models.UserImageFile", b =>
                {
                    b.Property<int>("UserImageFileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .HasMaxLength(100);

                    b.Property<int>("EventId");

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<byte[]>("content");

                    b.HasKey("UserImageFileId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("UserImageFile");
                });

            modelBuilder.Entity("KitundaChurch.Models.Category", b =>
                {
                    b.HasOne("KitundaChurch.Models.News")
                        .WithMany("category")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("KitundaChurch.Models.Matoleo", b =>
                {
                    b.HasOne("KitundaChurch.Models.ChurchMembers", "ChurchMembers")
                        .WithMany("matoleo")
                        .HasForeignKey("ChurchMembersName");
                });

            modelBuilder.Entity("KitundaChurch.Models.Matumizi", b =>
                {
                    b.HasOne("KitundaChurch.Models.Department", "department")
                        .WithMany("matumizi")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KitundaChurch.Models.Mengineyo", b =>
                {
                    b.HasOne("KitundaChurch.Models.Matoleo", "Matoleo")
                        .WithMany("mengineyo")
                        .HasForeignKey("MatoleoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KitundaChurch.Models.Song", b =>
                {
                    b.HasOne("KitundaChurch.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KitundaChurch.Models.UserImageFile", b =>
                {
                    b.HasOne("KitundaChurch.Models.Event", "Event")
                        .WithOne("Image")
                        .HasForeignKey("KitundaChurch.Models.UserImageFile", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
