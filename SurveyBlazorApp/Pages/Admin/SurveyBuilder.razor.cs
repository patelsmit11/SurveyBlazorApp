using Microsoft.AspNetCore.Components;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;
using SurveyBlazorApp.Shared.Components;
using System.Collections.Generic;
using System.Linq;

namespace SurveyBlazorApp.Pages.Admin
{
    public partial class SurveyBuilder
    {
        [Inject] private IQuestionRepository QuestionRepository { get; set; }
        private List<Question> Questions { get; set; }
        protected DeleteConfirmBase DeleteConfirmation { get; set; }
        private int QuestionId { get; set; }

        protected override void OnInitialized()
        {
            Questions = QuestionRepository.GetAll().ToList();
            base.OnInitialized();
        }

        protected void DeleteClick(int questionId)
        {
            QuestionId = questionId;
            DeleteConfirmation.Show();
        }

        protected void ConfirmDeleteClick(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                QuestionRepository.Delete(QuestionId);
                var question = Questions.FirstOrDefault(q => q.QuestionId == QuestionId);
                if (question != null)
                {
                    Questions.Remove(question);
                }
                StateHasChanged();
            }
        }
    }
}
