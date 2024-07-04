using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class LessonGradeRepository : RepositoryBase<LessonGrade>, ILessonGradeRepository
{
    public LessonGradeRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}