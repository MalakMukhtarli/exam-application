namespace ExamApplication.Core.Entities.Models;

public class LessonGradeTeacher : BaseEntity, ISoftDeletedEntity
{
    public LessonGradeTeacher()
    {
        Exams = new HashSet<Exam>();
    }
    
    public int LessonId { get; set; }
    public virtual Lesson Lesson { get; set; }
    
    public int GradeId { get; set; }
    public virtual Grade Grade { get; set; }
    
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public bool Deleted { get; set; }
    public virtual ICollection<Exam> Exams { get; set; }

}