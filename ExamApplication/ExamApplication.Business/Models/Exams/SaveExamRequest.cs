namespace ExamApplication.Business.Models.Exams;

public class SaveExamRequest
{
    public DateTime? ExamDate { get; set; }
    public int? LessonGradeId { get; set; }
}