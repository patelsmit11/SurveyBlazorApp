using Microsoft.AspNetCore.Components;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;
using System.Collections.Generic;

namespace SurveyBlazorApp.Pages.Admin
{
    public partial class SurveyReportComponent
    {
        [Inject] private IQuestionRepository QuestionRepository { get; set; }
        private IEnumerable<Question> Questions { get; set; }

        protected override void OnInitialized()
        {
            Questions = QuestionRepository.GetAll();
            base.OnInitialized();
        }
    }
}
