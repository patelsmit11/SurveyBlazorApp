using Microsoft.AspNetCore.Components;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;

namespace SurveyBlazorApp.Pages.Admin
{
    public partial class QuestionComponent
    {
        [Inject] private IQuestionRepository QuestionRepository { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public int QuestionId { get; set; }
        private Question Question { get; set; } = new() { IsRequired = true };

        protected override void OnInitialized()
        {
            if(QuestionId > 0)
            {
                Question = QuestionRepository.GetById(QuestionId);
            }
            base.OnInitialized();
        }
        private void HandleValidSubmit()
        {
            if (QuestionId > 0)
            {
                QuestionRepository.Update(Question);
            }
            else
            {
                QuestionRepository.Add(Question);
            }
            NavigationManager.NavigateTo("admin/survey/builder");
        }
    }
}
