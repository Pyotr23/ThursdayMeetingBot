﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThursdayMeetingBot.Libraries.Data.Contexts;

namespace ThursdayMeetingBot.Libraries.Data.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20210726164144_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ThursdayMeetingBot.Libraries.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<long>("TelegramChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("telegram_chat_id");

                    b.Property<int>("TelegramId")
                        .HasColumnType("integer")
                        .HasColumnName("telegram_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("TelegramChatId")
                        .HasDatabaseName("ix_users_telegram_chat_id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}