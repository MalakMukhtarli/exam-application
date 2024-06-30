using ExamApplication.Business.Models.Teachers;

namespace ExamApplication.Business.Services.Teachers;

public interface ITeacherService
{
    Task<List<TeacherDto>> GetAll();
    Task<int> Create(SaveTeacherRequest request);
    Task CreateLessonGradeTeacher(int teacherId, List<SaveLessonGradeTeacherRequest> requests);
    Task<TeacherDto> GetById(int teacherId);
    Task<int> Update(int teacherId, List<UpdateTeacherRequest> requests);
    Task Delete(int teacherId);
}