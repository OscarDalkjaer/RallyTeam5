﻿// <auto-generated />
using System;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20240519163241_123")]
    partial class _123
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessLogic.Models.Event", b =>
                {
                    b.Property<int?>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EventId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BusinessLogic.Models.Judge", b =>
                {
                    b.Property<int?>("JudgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("JudgeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JudgeId");

                    b.ToTable("Judges");
                });

            modelBuilder.Entity("DataAccess.DataAccessModels.CourseDataAccessModel", b =>
                {
                    b.Property<int>("CourseDataAccessModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseDataAccessModelId"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("CourseDataAccessModelId");

                    b.ToTable("CourseDataAccessModels");
                });

            modelBuilder.Entity("DataAccess.DataAccessModels.CourseExerciseRelation", b =>
                {
                    b.Property<int>("CourseExerciseRelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseExerciseRelationId"));

                    b.Property<int>("CourseDataAccessModelId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseDataAccessModelId")
                        .HasColumnType("int");

                    b.HasKey("CourseExerciseRelationId");

                    b.HasIndex("CourseDataAccessModelId");

                    b.HasIndex("ExerciseDataAccessModelId");

                    b.ToTable("CourseExerciseRelations");
                });

            modelBuilder.Entity("DataAccess.DataAccessModels.ExerciseDataAccessModel", b =>
                {
                    b.Property<int>("ExerciseDataAccessModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseDataAccessModelId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HandlingPosition")
                        .HasColumnType("int");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<bool>("Stationary")
                        .HasColumnType("bit");

                    b.Property<int?>("TypeOfJump")
                        .HasColumnType("int");

                    b.Property<bool>("WithCone")
                        .HasColumnType("bit");

                    b.HasKey("ExerciseDataAccessModelId");

                    b.ToTable("ExerciseDataAccessModels");

                    b.HasData(
                        new
                        {
                            ExerciseDataAccessModelId = -1,
                            Description = "",
                            HandlingPosition = 2,
                            Name = "",
                            Number = 0,
                            Stationary = false,
                            WithCone = false
                        },
                        new
                        {
                            ExerciseDataAccessModelId = 2,
                            Description = "",
                            HandlingPosition = 2,
                            Name = "",
                            Number = 2,
                            Stationary = false,
                            WithCone = false
                        });
                });

            modelBuilder.Entity("DataAccess.DataAccessModels.CourseExerciseRelation", b =>
                {
                    b.HasOne("DataAccess.DataAccessModels.CourseDataAccessModel", "CourseDataAccessModel")
                        .WithMany("CourseExerciseRelations")
                        .HasForeignKey("CourseDataAccessModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DataAccessModels.ExerciseDataAccessModel", "ExerciseDataAccessModel")
                        .WithMany()
                        .HasForeignKey("ExerciseDataAccessModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseDataAccessModel");

                    b.Navigation("ExerciseDataAccessModel");
                });

            modelBuilder.Entity("DataAccess.DataAccessModels.CourseDataAccessModel", b =>
                {
                    b.Navigation("CourseExerciseRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
