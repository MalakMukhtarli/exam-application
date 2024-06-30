namespace ExamApplication.Business.Models.Lessons;

public class LessonDto : BaseDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public List<int> Grades { get; set; }
}