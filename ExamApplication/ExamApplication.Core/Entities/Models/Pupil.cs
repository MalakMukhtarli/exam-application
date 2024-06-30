using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Core.Entities.Models;

public class Pupil : CommonEntity
{
    public Pupil()
    {
        PupilGrades = new HashSet<PupilGrade>();
        PupilExams = new HashSet<PupilExam>();
    }

    [Required] 
    [Column(TypeName = "numeric(5,0)")]
    public int Number { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string Surname { get; set; }

    public virtual ICollection<PupilGrade> PupilGrades { get; set; }
    public virtual ICollection<PupilExam> PupilExams { get; set; }
}