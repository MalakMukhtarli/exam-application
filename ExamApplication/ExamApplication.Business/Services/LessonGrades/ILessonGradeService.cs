using ExamApplication.Business.Models.LessonGrades;

namespace ExamApplication.Business.Services.LessonGrades;

public interface ILessonGradeService
{
    Task<List<LessonGradeDto>> GetAllAsync();
}