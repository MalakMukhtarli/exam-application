using ExamApplication.Business.Models.Grades;

namespace ExamApplication.Business.Services.Grades;

public interface IGradeService
{
    Task<List<GradeDto>> GetAllAsync();
    Task CheckByIdAsync(int gradeId);
    Task<int> CreateAsync(byte grade);
    Task<GradeDto> GetByIdAsync(int gradeId);
    Task<int> UpdateAsync(int gradeId, UpdateGradeRequest request);
    Task DeleteAsync(int gradeId);
}