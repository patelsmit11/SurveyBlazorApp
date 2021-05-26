using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Models.Validators;
using SurveyBlazorApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SurveyBlazorApp.Pages
{
    public partial class SurveyForm
    {
        [Inject] private IQuestionRepository QuestionRepository { get; set; }
        [Inject] private ISurveyResponseRepository SurveyResponseRepository { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IHttpContextAccessor HttpContextAccessor { get; set; }
        private IEnumerable<Question> Questions { get; set; }
        private SurveyResponses SurveyResponses { get; set; } = new SurveyResponses { List = new List<SurveyResponse>() };
        private string CurrentUserName { get; set; }
        private bool IsSurveyCompleted { get; set; } = false;

        protected override void OnInitialized()
        {
            CurrentUserName = HttpContextAccessor.HttpContext.User.Identity.Name;
            if (SurveyResponseRepository.GetByUserName(CurrentUserName).Any())
            {
                IsSurveyCompleted = true;
            }
            else
            {
                Questions = QuestionRepository.GetAll();
                foreach (var question in Questions)
                {
                    SurveyResponses.List.Add(new SurveyResponse { QuestionId = question.QuestionId, Question = question });
                }
            }

            base.OnInitialized();
        }

        private void HandleValidSubmit()
        {
            foreach (var surveyResponse in SurveyResponses.List)
            {
                surveyResponse.CreatedBy = CurrentUserName;
                SurveyResponseRepository.Add(surveyResponse);
            }

            NavigationManager.NavigateTo($"survey/completed");
        }

        private void handleClick(SelectListItem item)
        {
            //item.Selected = !item.Selected;
            //Do something crazy
        }

    }
}
