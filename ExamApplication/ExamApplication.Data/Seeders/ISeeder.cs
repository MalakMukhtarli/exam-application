using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Data.Seeders;

public interface ISeeder
{
    void Seed(ModelBuilder modelBuilder);
}