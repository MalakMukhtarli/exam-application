using ExamApplication.Business.Models.Lessons;
using ExamApplication.Core.Entities.Models;

namespace ExamApplication.Business.Services.Lessons;

public interface ILessonService
{
    Task<List<LessonDto>> GetAllAsync();
    Task<int> CreateAsync(SaveLessonRequest request);
    Task CheckByIdAsync(int lessonId);
    Task<LessonGrade> CheckByGradeIdAsync(int lessonId, int gradeId);
    Task<LessonGrade> CheckByLessonGradeIdAsync(int lessonGradeId);
    Task<LessonDto> GetByIdAsync(int lessonId);
    Task<int> UpdateAsync(int lessonId, UpdateLessonRequest request);
    Task DeleteAsync(int lessonId);
}