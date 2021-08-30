﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThursdayMeetingBot.Libraries.Data.Contexts;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20210827230723_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Chat", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatTypeId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.ChatType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChatTypes");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.HasIndex("MessageId", "ChatId")
                        .IsUnique();

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("ThursdayMeetingBot.Libraries.Data.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThursdayMeetingBot.Libraries.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Chat", b =>
                {
                    b.HasOne("ThursdayMeetingBot.Libraries.Data.Models.ChatType", "ChatType")
                        .WithMany()
                        .HasForeignKey("ChatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatType");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Message", b =>
                {
                    b.HasOne("ThursdayMeetingBot.Libraries.Data.Models.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThursdayMeetingBot.Libraries.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}