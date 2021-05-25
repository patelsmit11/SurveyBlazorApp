using SurveyBlazorApp.Models;
using System.Collections.Generic;

namespace SurveyBlazorApp.Services.Interfaces
{
    public interface ISurveyResponseRepository
    {
        void Add(SurveyResponse surveyResponse);
        void Update(SurveyResponse surveyResponse);
        void Delete(int surveyResponseId);
        SurveyResponse GetById(int surveyResponseId);
        IEnumerable<SurveyResponse> GetByUserName(string username);
        IEnumerable<SurveyResponse> GetAll();
    }
}
