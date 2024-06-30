using ExamApplication.Business.Models.PupilExams;

namespace ExamApplication.Business.Models.Exams;

public class ExamDto : BaseDto
{
    public DateTime ExamDate { get; set; }
    public string LessonCode { get; set; }
    public List<PupilExamDto> PupilExams { get; set; }
}