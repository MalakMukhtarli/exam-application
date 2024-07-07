using ExamApplication.Business.Models.Exams;
using ExamApplication.Business.Models.PupilExams;

namespace ExamApplication.Business.Services.Exams;

public interface IExamService
{
    Task<List<ExamDto>> GetAll();
    Task<List<ExamForSelectDto>> GetAllForSelect();
    Task<int> Create(SaveExamRequest request);
    Task<ExamDto> GetById(int examId);
    Task<int> Update(int examId, UpdateExamRequest request);
    Task<int> UpdatePupilExam(UpdatePupilExamRequest request);
    Task Delete(int examId);
    Task<List<PupilExamSelectDto>> GetAllPupilsByExamId(int examId);
}