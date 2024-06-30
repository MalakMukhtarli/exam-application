using ExamApplication.Business.Models.Grades;

namespace ExamApplication.Business.Services.Grades;

public interface IGradeService
{
    Task<List<GradeDto>> GetAll();
    Task CheckById(int gradeId);
    Task<int> Create(byte grade);
    Task<GradeDto> GetById(int gradeId);
    Task<int> Update(int gradeId, UpdateGradeRequest request);
    Task Delete(int gradeId);
}