using FluentValidation;
using System.Collections.Generic;

namespace SurveyBlazorApp.Models.Validators
{
    public class SurveyResponseValidator : AbstractValidator<SurveyResponses>
    {
        public SurveyResponseValidator()
        {
            RuleForEach(x => x.List).Where(x => x.Question.IsRequired == true).ChildRules(c =>
              {
                  c.RuleFor(p => p.Value).NotEmpty().WithMessage("This question requires an answer.");
              });
        }
    }

    public class SurveyResponses
    {
        public List<SurveyResponse> List { get; set; }
    }
}
