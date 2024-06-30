using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class PupilRepository : RepositoryBase<Pupil>, IPupilRepository
{
    public PupilRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}