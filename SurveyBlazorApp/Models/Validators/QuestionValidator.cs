using FluentValidation;

namespace SurveyBlazorApp.Models.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.Title).NotEmpty().WithMessage("'Question' must not be empty.").MaximumLength(255);
            When(q => q.QuestionType != Enums.QuestionTypes.Text, () => {
                RuleFor(q => q.Options).NotEmpty().WithMessage("'Options' must not be empty.");
            });
        }

    }
}
