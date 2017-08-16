using Foundation.DataAccess.EF;
using Quiz.Database;
using Quiz.Domain.Entities;
using Quiz.Domain.Repositories;

namespace Quiz.Application.Ports.Repositories
{
    public class QuestionRepository : GenericEFRepository<Question, QuizDbContext>, IQuestionRepository
    {
        public QuestionRepository(QuizDbContext context) : base(context)
        {
        }
    }
}
