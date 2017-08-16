using Foundation.Domain.Entity;

namespace Quiz.Domain.Entities
{
    public class GradingSystem: EntityBase
    {
        public EQuestionType? QuestionType  {get;set;}

        public int? Level { get; set; }

        public int Grade { get; set; }
    }
}
