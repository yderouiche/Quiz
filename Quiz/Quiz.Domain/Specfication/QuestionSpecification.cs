using NSpecifications;
using Quiz.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quiz.Domain.Specfication
{
    public class QuestionTextSpecification : Specification<Question>
    {
        public override Expression<Func<Question, bool>> Expression => (q => !string.IsNullOrEmpty(q.Text.Trim()));
    }

    public class QuestionNbAnswersSpecification : Specification<Question>
    {
        public override Expression<Func<Question, bool>> Expression => (q=>q.Answers.Count>1);
    }


    public class QuestionRightAnswerSpecification : Specification<Question>
    {
        public override Expression<Func<Question, bool>> Expression => (q => q.Answers.Where(a=>a.IsRight).Count() >= 1);
    }
}
