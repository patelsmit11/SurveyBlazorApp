using SurveyBlazorApp.Models;
using System.Collections.Generic;

namespace SurveyBlazorApp.Services.Interfaces
{
    public interface IQuestionRepository
    {
        void Add(Question question);
        void Update(Question question);
        void Delete(int questionId);
        Question GetById(int questionId);
        IEnumerable<Question> GetAll();
    }
}
