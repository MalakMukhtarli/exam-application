using ExamApplication.Business.Models.Teachers;

namespace ExamApplication.Business.Services.Teachers;

public interface ITeacherService
{
    Task<List<TeacherDto>> GetAllAsync();
    Task<List<TeacherDto>> GetAllForSelectAsync();
    Task<int> CreateAsync(SaveTeacherRequest request);
    Task CreateLessonGradeTeacherAsync(int teacherId, SaveLessonGradeTeacherRequest request);
    Task<TeacherDto> GetByIdAsync(int teacherId);
    Task<int> UpdateAsync(int teacherId, List<UpdateTeacherRequest> requests);
    Task DeleteAsync(int teacherId);
}