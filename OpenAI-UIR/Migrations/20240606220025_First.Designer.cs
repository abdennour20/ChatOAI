﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenAI_UIR.Data;

#nullable disable

namespace OpenAIUIR.Migrations
{
    [DbContext(typeof(ConversationContextDb))]
    [Migration("20240606220025_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OpenAI_UIR.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Conversation")
                        .HasColumnType("int");

                    b.Property<string>("questionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Conversation");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Question")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Question")
                        .IsUnique();

                    b.ToTable("Response");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Question", b =>
                {
                    b.HasOne("OpenAI_UIR.Models.Conversation", "Conversation")
                        .WithMany("Questions")
                        .HasForeignKey("Id_Conversation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Response", b =>
                {
                    b.HasOne("OpenAI_UIR.Models.Question", "Question")
                        .WithOne("Response")
                        .HasForeignKey("OpenAI_UIR.Models.Response", "Id_Question")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Conversation", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("OpenAI_UIR.Models.Question", b =>
                {
                    b.Navigation("Response")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
