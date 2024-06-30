using FluentValidation;

namespace ExamApplication.Business.Models.Exams;

public class UpdateExamRequestValidator : BaseValidator<UpdateExamRequest>
{
    public UpdateExamRequestValidator() : base()
    {
        RuleFor(e => e.ExamDate)
            .NotEmpty().WithMessage("İmtahan saatı boş ola bilməz");
    }
}