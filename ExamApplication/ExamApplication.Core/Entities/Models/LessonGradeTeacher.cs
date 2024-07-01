namespace ExamApplication.Core.Entities.Models;

public class LessonGradeTeacher : BaseEntity, ISoftDeletedEntity
{
    public int LessonGradeId { get; set; }
    public virtual LessonGrade LessonGrade { get; set; }
    
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
    public bool Deleted { get; set; }
}