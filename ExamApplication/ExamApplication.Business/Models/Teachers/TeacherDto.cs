using ExamApplication.Business.Models.LessonGrades;

namespace ExamApplication.Business.Models.Teachers;

public class TeacherDto : BaseDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<LessonGradeForTeacher> LessonGrades { get; set; }
}