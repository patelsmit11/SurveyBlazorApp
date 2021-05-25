using Microsoft.EntityFrameworkCore;
using SurveyBlazorApp.Data;
using SurveyBlazorApp.Models;
using SurveyBlazorApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SurveyBlazorApp.Services
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly SurveyDbContext dbContext = new();

        public void Add(Question question)
        {
            question.SurveyResponses = null;
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
        }

        public void Delete(int questionId)
        {
            var question = dbContext.Questions.FirstOrDefault(t=>t.QuestionId == questionId);
            if(question != null)
            {
                var surveyResponses = dbContext.SurveyResponses.Where(s => s.QuestionId == questionId);
                dbContext.SurveyResponses.RemoveRange(surveyResponses);
                dbContext.Questions.Remove(question);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return dbContext.Questions.Include(q => q.SurveyResponses);
        }

        public Question GetById(int questionId)
        {
            return dbContext.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        }

        public void Update(Question question)
        {
            question.SurveyResponses = null;
            dbContext.Questions.Attach(question);
            dbContext.Entry(question).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
