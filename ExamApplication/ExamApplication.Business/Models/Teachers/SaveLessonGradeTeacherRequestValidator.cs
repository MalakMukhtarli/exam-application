using FluentValidation;

namespace ExamApplication.Business.Models.Teachers;

public class SaveLessonGradeTeacherRequestValidator:  BaseValidator<SaveLessonGradeTeacherRequest>
{
    public SaveLessonGradeTeacherRequestValidator() : base()
    {
        RuleFor(e => e.LessonGradeIds)
            .NotEmpty().WithMessage("Dərs və sinif mütləq seçilməlidir");
        
        // RuleFor(e => e.GradeId)
        //     .NotEmpty().WithMessage("Sinif mütləq seçilməlidir");
        // RuleFor(e => e.LessonId)
        //     .NotEmpty().WithMessage("Dərs mütləq seçilməlidir");
    }
}