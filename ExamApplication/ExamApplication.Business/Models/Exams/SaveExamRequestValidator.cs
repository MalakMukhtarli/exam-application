using FluentValidation;

namespace ExamApplication.Business.Models.Exams;

public class SaveExamRequestValidator : BaseValidator<SaveExamRequest>
{
    public SaveExamRequestValidator() : base()
    {
        RuleFor(e => e.ExamDate)
            .NotNull().WithMessage("İmtahan saatı boş ola bilməz");
        RuleFor(e => e.LessonGradeId)
            .NotEmpty().WithMessage("Sinif və dərs boş ola bilməz");
    }
}