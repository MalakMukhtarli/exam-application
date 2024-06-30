using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
{
    public GradeRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}