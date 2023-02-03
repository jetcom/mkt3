﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mkt3.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mkt3.Migrations
{
    [DbContext(typeof(Mkt3Context))]
    [Migration("20230202115526_linelength")]
    partial class linelength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mkt3.Data.Exam", b =>
                {
                    b.Property<string>("examID")
                        .HasColumnType("text");

                    b.Property<string>("courseNumber")
                        .HasColumnType("text");

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("defaultLineLength")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("defaultPoints")
                        .HasColumnType("integer");

                    b.Property<string>("defaultSolutionSpace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("department")
                        .HasColumnType("text");

                    b.Property<string>("examName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("instructor")
                        .HasColumnType("text");

                    b.Property<int?>("maxPoints")
                        .HasColumnType("integer");

                    b.Property<string>("note")
                        .HasColumnType("text");

                    b.Property<string>("school")
                        .HasColumnType("text");

                    b.Property<string>("term")
                        .HasColumnType("text");

                    b.Property<bool>("useCheckboxes")
                        .HasColumnType("boolean");

                    b.HasKey("examID", "courseNumber");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Mkt3.Data.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<List<string>>("ExamTags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("LineLength")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionLabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Solutions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("WrongAnswers")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("customLineLength")
                        .HasColumnType("boolean");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Mkt3.Data.QuestionTopic", b =>
                {
                    b.Property<int>("QuestionID")
                        .HasColumnType("integer");

                    b.Property<int>("TopicID")
                        .HasColumnType("integer");

                    b.HasKey("QuestionID", "TopicID");

                    b.ToTable("QuestionTopics");
                });

            modelBuilder.Entity("Mkt3.Data.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}
