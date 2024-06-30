using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Core.Entities.Models;

public class Teacher : CommonEntity
{
    public Teacher()
    {
        LessonGradeTeachers = new HashSet<LessonGradeTeacher>();
    }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string Surname { get; set; }

    public virtual ICollection<LessonGradeTeacher> LessonGradeTeachers { get; set; }
}