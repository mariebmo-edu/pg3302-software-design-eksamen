﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20211118111812_V001")]
    partial class V001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseCode")
                        .HasColumnType("TEXT");

                    b.Property<float>("CoursePoints")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterEnum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LectureDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Published")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskSetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TaskSetId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterEnum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskSetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TaskSetId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.TaskSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("LectureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaskSets");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Semester", "Semester")
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Lecture", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PG332_SoftwareDesign_EksamenH21.TaskSet", "TaskSet")
                        .WithMany()
                        .HasForeignKey("TaskSetId");

                    b.Navigation("Course");

                    b.Navigation("TaskSet");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Model.Address", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Model.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("PG332_SoftwareDesign_EksamenH21.Model.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.Model.User", "User")
                        .WithMany("Semesters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Task", b =>
                {
                    b.HasOne("PG332_SoftwareDesign_EksamenH21.TaskSet", "TaskSet")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskSet");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Course", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Model.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Semesters");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.Semester", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("PG332_SoftwareDesign_EksamenH21.TaskSet", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
