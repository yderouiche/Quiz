using Foundation.Domain.Entity;
using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class QuizAnswers: EntityBase
    {
        public int QuestionId {get;set;}

        public IList<int> AnswerIds { get; set; }
    }
}
