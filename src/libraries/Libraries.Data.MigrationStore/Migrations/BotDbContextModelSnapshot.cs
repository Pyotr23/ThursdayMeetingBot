﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThursdayMeetingBot.Libraries.Data.Contexts;

namespace ThursdayMeetingBot.Libraries.Data.MigrationStore.Migrations
{
    [DbContext(typeof(BotDbContext))]
    partial class BotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("bigint")
                        .HasColumnName("chats_id");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer")
                        .HasColumnName("users_id");

                    b.HasKey("ChatsId", "UsersId")
                        .HasName("pk_chat_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_chat_user_users_id");

                    b.ToTable("chat_user");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Chat", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<int>("ChatTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_type_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_chats");

                    b.HasIndex("ChatTypeId")
                        .HasDatabaseName("ix_chats_chat_type_id");

                    b.ToTable("chats");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.ChatType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_chat_types");

                    b.ToTable("chat_types");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("MessageId")
                        .HasColumnType("integer")
                        .HasColumnName("message_id");

                    b.Property<string>("Text")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_messages");

                    b.HasIndex("ChatId")
                        .HasDatabaseName("ix_messages_chat_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_messages_user_id");

                    b.HasIndex("MessageId", "ChatId")
                        .IsUnique()
                        .HasDatabaseName("ix_messages_message_id_chat_id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
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
