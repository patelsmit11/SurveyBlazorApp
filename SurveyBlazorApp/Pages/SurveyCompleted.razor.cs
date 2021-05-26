using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;
using System.Collections.Generic;

namespace SurveyBlazorApp.Pages
{
    public partial class SurveyCompleted
    {
        [Inject] private ISurveyResponseRepository SurveyResponseRepository { get; set; }
        [Inject] private IHttpContextAccessor HttpContextAccessor { get; set; }
        private IEnumerable<SurveyResponse> SurveyResponses { get; set; }

        protected override void OnInitialized()
        {
            SurveyResponses = SurveyResponseRepository.GetByUserName(HttpContextAccessor.HttpContext.User.Identity.Name);
            base.OnInitialized();
        }
    }
}
