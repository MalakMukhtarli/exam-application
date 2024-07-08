using ExamApplication.Business.Models.Exams;
using ExamApplication.Business.Models.Grades;
using ExamApplication.Business.Models.LessonGrades;
using ExamApplication.Business.Models.Teachers;

namespace ExamApplication.Mvc.ViewModels;

public class GetAllDataViewModel
{
    public List<GradeDto> Grades { get; set; }
    public List<LessonGradeDto> LessonGrades { get; set; }
    public List<TeacherDto> Teachers { get; set; }
    public List<ExamForSelectDto> Exams { get; set; }
}