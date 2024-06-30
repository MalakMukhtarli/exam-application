using FluentValidation;

namespace ExamApplication.Business.Models;

public class BaseValidator<T> : AbstractValidator<T> where T : class
{
    public BaseValidator() : base()
    {

    }
    private protected bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}