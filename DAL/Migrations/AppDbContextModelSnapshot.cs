﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Domain.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoardName");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Domain.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameName")
                        .HasMaxLength(64);

                    b.Property<int?>("Player1UserId");

                    b.Property<int?>("Player2UserId");

                    b.HasKey("GameId");

                    b.HasIndex("Player1UserId");

                    b.HasIndex("Player2UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NodeValue")
                        .HasMaxLength(64);

                    b.Property<int?>("RowNodeId");

                    b.HasKey("NodeId");

                    b.HasIndex("RowNodeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("Domain.RowNode", b =>
                {
                    b.Property<int>("RowNodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BoardId");

                    b.HasKey("RowNodeId");

                    b.HasIndex("BoardId");

                    b.ToTable("RowNodes");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OppenentBoardBoardId");

                    b.Property<int?>("SelfBoardBoardId");

                    b.HasKey("UserId");

                    b.HasIndex("OppenentBoardBoardId");

                    b.HasIndex("SelfBoardBoardId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Game", b =>
                {
                    b.HasOne("Domain.User", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1UserId");

                    b.HasOne("Domain.User", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2UserId");
                });

            modelBuilder.Entity("Domain.Node", b =>
                {
                    b.HasOne("Domain.RowNode")
                        .WithMany("Nodes")
                        .HasForeignKey("RowNodeId");
                });

            modelBuilder.Entity("Domain.RowNode", b =>
                {
                    b.HasOne("Domain.Board")
                        .WithMany("RowNodes")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Board", "OppenentBoard")
                        .WithMany()
                        .HasForeignKey("OppenentBoardBoardId");

                    b.HasOne("Domain.Board", "SelfBoard")
                        .WithMany()
                        .HasForeignKey("SelfBoardBoardId");
                });
#pragma warning restore 612, 618
        }
    }
}
