using Microsoft.EntityFrameworkCore;
using SurveyBlazorApp.Data;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SurveyBlazorApp.Services
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly SurveyDbContext dbContext = new();

        public void Add(SurveyResponse surveyResponse)
        {
            surveyResponse.Question = null;
            dbContext.SurveyResponses.Add(surveyResponse);
            dbContext.SaveChanges();
        }

        public void Delete(int surveyResponseId)
        {
            var question = dbContext.SurveyResponses.FirstOrDefault(t => t.SurveyResponseId == surveyResponseId);
            if (question != null)
            {
                dbContext.Remove(question);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<SurveyResponse> GetAll()
        {
            return dbContext.SurveyResponses;
        }

        public SurveyResponse GetById(int surveyResponseId)
        {
            return dbContext.SurveyResponses.FirstOrDefault(q => q.SurveyResponseId == surveyResponseId);
        }

        public IEnumerable<SurveyResponse> GetByUserName(string username)
        {
            return dbContext.SurveyResponses.Where(s => s.CreatedBy.ToLower().Equals(username.ToLower())).Include(s => s.Question);
        }

        public void Update(SurveyResponse surveyResponse)
        {
            surveyResponse.Question = null;
            dbContext.SurveyResponses.Attach(surveyResponse);
            dbContext.Entry(surveyResponse).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
