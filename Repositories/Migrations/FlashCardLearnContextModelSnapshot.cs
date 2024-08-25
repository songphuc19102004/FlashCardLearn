﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Models;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(FlashCardLearnContext))]
    partial class FlashCardLearnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Repositories.Models.FlashCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer");

                    b.Property<int>("FlashcardsetId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("flashcardset_id");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("question");

                    b.HasKey("Id")
                        .HasName("PK__FlashCar__3213E83F666D7250");

                    b.HasIndex("FlashcardsetId");

                    b.ToTable("FlashCard", (string)null);
                });

            modelBuilder.Entity("Repositories.Models.FlashCardSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("Progress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("progress");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__FlashCar__3213E83FE1539727");

                    b.ToTable("FlashCardSet", (string)null);
                });

            modelBuilder.Entity("Repositories.Models.FlashCard", b =>
                {
                    b.HasOne("Repositories.Models.FlashCardSet", "Flashcardset")
                        .WithMany("FlashCards")
                        .HasForeignKey("FlashcardsetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FlashCard__flash__267ABA7A");

                    b.Navigation("Flashcardset");
                });

            modelBuilder.Entity("Repositories.Models.FlashCardSet", b =>
                {
                    b.Navigation("FlashCards");
                });
#pragma warning restore 612, 618
        }
    }
}
