namespace ExamApplication.Core.Entities.Models;

public class Exam : CommonEntity
{
    public Exam()
    {
        PupilExams = new HashSet<PupilExam>();
    }
    
    public DateTime ExamDate { get; set; }
    
    public int LessonGradeTeacherId { get; set; }
    public virtual LessonGradeTeacher LessonGradeTeacher { get; set; }
    
    public virtual ICollection<PupilExam> PupilExams { get; set; }
}