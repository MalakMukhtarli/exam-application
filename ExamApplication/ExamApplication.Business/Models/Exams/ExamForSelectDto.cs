namespace ExamApplication.Business.Models.Exams;

public class ExamForSelectDto : BaseDto
{
    public string ExamDate { get; set; }
    public string Lesson { get; set; }
    public int Grade { get; set; }
}