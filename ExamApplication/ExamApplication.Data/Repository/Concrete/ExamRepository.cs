using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class ExamRepository : RepositoryBase<Exam>, IExamRepository
{
    public ExamRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}