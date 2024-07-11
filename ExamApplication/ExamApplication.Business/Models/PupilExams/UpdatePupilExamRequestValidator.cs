using FluentValidation;

namespace ExamApplication.Business.Models.PupilExams;

public class UpdatePupilExamRequestValidator : BaseValidator<UpdatePupilExamRequest>
{
    public UpdatePupilExamRequestValidator() : base()
    {
        RuleFor(e => e.PupilExamId)
            .NotEmpty().WithMessage("Şagird boş ola bilməz");
        RuleFor(e => e.Mark)
            .NotNull().WithMessage("Qiymət boş ola bilməz")
            .Must(w => w is >= 1 and <= 5).WithMessage("Qiymət 1 ilə 5 arasında ola bilər");
    }
}