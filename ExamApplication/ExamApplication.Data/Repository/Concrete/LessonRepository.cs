using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}