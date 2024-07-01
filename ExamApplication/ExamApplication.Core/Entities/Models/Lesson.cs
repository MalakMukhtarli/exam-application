using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Core.Entities.Models;

public class Lesson : CommonEntity
{
    public Lesson()
    {
        LessonGrades = new HashSet<LessonGrade>();
    }

    [Required] 
    [Column(TypeName = "char(3)")]
    public string Code { get; set; }
    [Required] 
    [Column(TypeName = "nvarchar(30)")]
    public string Name { get; set; }
    public virtual ICollection<LessonGrade> LessonGrades { get; set; }
}