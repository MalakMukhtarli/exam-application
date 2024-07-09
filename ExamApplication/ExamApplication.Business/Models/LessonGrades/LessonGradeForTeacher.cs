namespace ExamApplication.Business.Models.LessonGrades;

public class LessonGradeForTeacher : BaseDto
{
    public string Lesson { get; set; }
    public List<int> Grades { get; set; }
}