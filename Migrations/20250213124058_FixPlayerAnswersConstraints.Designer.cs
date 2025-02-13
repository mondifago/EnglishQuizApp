﻿// <auto-generated />
using System;
using EnglishQuizApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishQuizApp.Migrations
{
    [DbContext(typeof(EnglishQuizAppContext))]
    [Migration("20250213124058_FixPlayerAnswersConstraints")]
    partial class FixPlayerAnswersConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnglishQuizApp.Models.AnswerOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerOptions");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.GameSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("QuizId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.PlayerAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameSessionId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SelectedAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("GameSessionId1");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedAnswerId");

                    b.ToTable("PlayerAnswers");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrectAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TimeLimitSeconds")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.AnswerOption", b =>
                {
                    b.HasOne("EnglishQuizApp.Models.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.GameSession", b =>
                {
                    b.HasOne("EnglishQuizApp.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnglishQuizApp.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.PlayerAnswer", b =>
                {
                    b.HasOne("EnglishQuizApp.Models.GameSession", "GameSession")
                        .WithMany()
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EnglishQuizApp.Models.GameSession", null)
                        .WithMany("AnswersGiven")
                        .HasForeignKey("GameSessionId1");

                    b.HasOne("EnglishQuizApp.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EnglishQuizApp.Models.AnswerOption", "SelectedAnswer")
                        .WithMany()
                        .HasForeignKey("SelectedAnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("Question");

                    b.Navigation("SelectedAnswer");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Question", b =>
                {
                    b.HasOne("EnglishQuizApp.Models.GameSession", null)
                        .WithMany("SelectedQuestions")
                        .HasForeignKey("GameSessionId");

                    b.HasOne("EnglishQuizApp.Models.Quiz", null)
                        .WithMany("QuestionPool")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.GameSession", b =>
                {
                    b.Navigation("AnswersGiven");

                    b.Navigation("SelectedQuestions");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("EnglishQuizApp.Models.Quiz", b =>
                {
                    b.Navigation("QuestionPool");
                });
#pragma warning restore 612, 618
        }
    }
}
