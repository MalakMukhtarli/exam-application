﻿// <auto-generated />
using System;
using ExamApplication.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamApplication.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LessonGradeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LessonGradeId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(2,0)");

                    b.HasKey("Id");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Deleted = false,
                            Value = 1m
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Deleted = false,
                            Value = 2m
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Deleted = false,
                            Value = 3m
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Deleted = false,
                            Value = 4m
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Deleted = false,
                            Value = 5m
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            Deleted = false,
                            Value = 6m
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            Deleted = false,
                            Value = 7m
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            Deleted = false,
                            Value = 8m
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            Deleted = false,
                            Value = 9m
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            Deleted = false,
                            Value = 10m
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            Deleted = false,
                            Value = 11m
                        });
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.LessonGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonGrade");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.LessonGradeTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LessonGradeId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonGradeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LessonGradeTeacher");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Number")
                        .HasColumnType("numeric(5,0)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.PupilExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<byte?>("Mark")
                        .HasColumnType("tinyint");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("PupilId");

                    b.ToTable("PupilExams");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.PupilGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("PupilId");

                    b.ToTable("PupilGrades");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Exam", b =>
                {
                    b.HasOne("ExamApplication.Core.Entities.Models.LessonGrade", "LessonGrade")
                        .WithMany("Exams")
                        .HasForeignKey("LessonGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonGrade");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.LessonGrade", b =>
                {
                    b.HasOne("ExamApplication.Core.Entities.Models.Grade", "Grade")
                        .WithMany("LessonGrades")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamApplication.Core.Entities.Models.Lesson", "Lesson")
                        .WithMany("LessonGrades")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.LessonGradeTeacher", b =>
                {
                    b.HasOne("ExamApplication.Core.Entities.Models.LessonGrade", "LessonGrade")
                        .WithMany("LessonGradeTeachers")
                        .HasForeignKey("LessonGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamApplication.Core.Entities.Models.Teacher", "Teacher")
                        .WithMany("LessonGradeTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonGrade");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.PupilExam", b =>
                {
                    b.HasOne("ExamApplication.Core.Entities.Models.Exam", "Exam")
                        .WithMany("PupilExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamApplication.Core.Entities.Models.Pupil", "Pupil")
                        .WithMany("PupilExams")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.PupilGrade", b =>
                {
                    b.HasOne("ExamApplication.Core.Entities.Models.Grade", "Grade")
                        .WithMany("PupilGrades")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamApplication.Core.Entities.Models.Pupil", "Pupil")
                        .WithMany("PupilGrades")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Exam", b =>
                {
                    b.Navigation("PupilExams");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Grade", b =>
                {
                    b.Navigation("LessonGrades");

                    b.Navigation("PupilGrades");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Lesson", b =>
                {
                    b.Navigation("LessonGrades");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.LessonGrade", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("LessonGradeTeachers");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Pupil", b =>
                {
                    b.Navigation("PupilExams");

                    b.Navigation("PupilGrades");
                });

            modelBuilder.Entity("ExamApplication.Core.Entities.Models.Teacher", b =>
                {
                    b.Navigation("LessonGradeTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
