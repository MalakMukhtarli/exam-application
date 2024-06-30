using ExamApplication.Core.Entities.Models;
using ExamApplication.Data.Persistence;

namespace ExamApplication.Data.Repository.Concrete;

public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext databaseContext) : base(databaseContext)
    {
    }
    
}