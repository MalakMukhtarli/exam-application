using ExamApplication.Business.Models.LessonGrades;
using ExamApplication.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Business.Services.LessonGrades;

public class LessonGradeManager : ILessonGradeService
{
    private readonly ILessonGradeRepository _lessonGradeRepository;

    public LessonGradeManager(ILessonGradeRepository lessonGradeRepository)
    {
        _lessonGradeRepository = lessonGradeRepository;
    }

    public async Task<List<LessonGradeDto>> GetAllAsync()
    {
        var response = await _lessonGradeRepository.GetQueryNoTracking()
            .Include(x => x.Lesson)
            .Include(x => x.Grade)
            .Where(x => x.Lesson.Active && x.Grade.Active)
            .Select(x => new LessonGradeDto
            {
                Id = x.Id,
                Lesson = x.Lesson.Name,
                Grade = x.Grade.Value
            })
            .ToListAsync();

        return response;
    }
}