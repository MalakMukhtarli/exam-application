using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApplication.Data.Migrations
{
    public partial class AddedLessonGradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_LessonGradeTeacher_LessonGradeTeacherId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonGradeTeacher_Grades_GradeId",
                table: "LessonGradeTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonGradeTeacher_Lessons_LessonId",
                table: "LessonGradeTeacher");

            migrationBuilder.DropIndex(
                name: "IX_LessonGradeTeacher_GradeId",
                table: "LessonGradeTeacher");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "LessonGradeTeacher");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "LessonGradeTeacher",
                newName: "LessonGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonGradeTeacher_LessonId",
                table: "LessonGradeTeacher",
                newName: "IX_LessonGradeTeacher_LessonGradeId");

            migrationBuilder.RenameColumn(
                name: "LessonGradeTeacherId",
                table: "Exams",
                newName: "LessonGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_LessonGradeTeacherId",
                table: "Exams",
                newName: "IX_Exams_LessonGradeId");

            migrationBuilder.AlterColumn<byte>(
                name: "Mark",
                table: "PupilExams",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(1,0)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LessonGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonGrade_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonGrade_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonGrade_GradeId",
                table: "LessonGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonGrade_LessonId",
                table: "LessonGrade",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_LessonGrade_LessonGradeId",
                table: "Exams",
                column: "LessonGradeId",
                principalTable: "LessonGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGradeTeacher_LessonGrade_LessonGradeId",
                table: "LessonGradeTeacher",
                column: "LessonGradeId",
                principalTable: "LessonGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_LessonGrade_LessonGradeId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonGradeTeacher_LessonGrade_LessonGradeId",
                table: "LessonGradeTeacher");

            migrationBuilder.DropTable(
                name: "LessonGrade");

            migrationBuilder.RenameColumn(
                name: "LessonGradeId",
                table: "LessonGradeTeacher",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonGradeTeacher_LessonGradeId",
                table: "LessonGradeTeacher",
                newName: "IX_LessonGradeTeacher_LessonId");

            migrationBuilder.RenameColumn(
                name: "LessonGradeId",
                table: "Exams",
                newName: "LessonGradeTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_LessonGradeId",
                table: "Exams",
                newName: "IX_Exams_LessonGradeTeacherId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Mark",
                table: "PupilExams",
                type: "numeric(1,0)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "LessonGradeTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LessonGradeTeacher_GradeId",
                table: "LessonGradeTeacher",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_LessonGradeTeacher_LessonGradeTeacherId",
                table: "Exams",
                column: "LessonGradeTeacherId",
                principalTable: "LessonGradeTeacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGradeTeacher_Grades_GradeId",
                table: "LessonGradeTeacher",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGradeTeacher_Lessons_LessonId",
                table: "LessonGradeTeacher",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
