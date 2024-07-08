using ExamApplication.Business.Models.Exams;
using ExamApplication.Business.Models.Lessons;
using ExamApplication.Business.Models.PupilExams;
using ExamApplication.Business.Models.Pupils;
using ExamApplication.Business.Models.Teachers;

namespace ExamApplication.Mvc.ViewModels;

public class CreateDataViewModel
{
    public SaveLessonRequest? Lesson { get; set; }
    public SaveTeacherRequest? Teacher { get; set; }
    public SavePupilRequest? Pupil { get; set; }
    public SaveExamRequest? Exam { get; set; }
    public int? teacherId { get; set; }
    public SaveLessonGradeTeacherRequest? LessonGradeTeacher { get; set; }
    public UpdatePupilExamRequest? PupilExam { get; set; }
}