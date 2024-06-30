using ExamApplication.Business.Models.Pupils;
using ExamApplication.Core.Entities.Models;

namespace ExamApplication.Business.Services.Pupils;

public interface IPupilService
{
    Task<List<PupilDto>> GetAll();
    Task<int> Create(SavePupilRequest request);
    Task<List<PupilGrade>> GetByGradeId(int gradeId);
    Task<PupilDto> GetById(int pupilId);
    Task<int> Update(int pupilId, UpdatePupilRequest request);
    Task Delete(int pupilId);
}