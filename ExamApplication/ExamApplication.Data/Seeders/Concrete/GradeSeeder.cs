using ExamApplication.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Data.Seeders.Concrete;

public class GradeSeeder : ISeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var i = 1;
        
        modelBuilder.Entity<Grade>().HasData(
            new
            {
                Id = i++,
                Value = 1,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 2,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 3,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 4,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 5,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 6,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 7,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 8,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 9,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i++,
                Value = 10,
                Deleted = false,
                Active = true
            },
            new
            {
                Id = i,
                Value = 11,
                Deleted = false,
                Active = true
            }
        );
    }
}