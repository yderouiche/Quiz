using NSpecifications;
using Quiz.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Quiz.Domain.Specfication
{
    public class QuizTemplateNameSpecification : Specification<QuizTemplate>
    {
        public override Expression<Func<QuizTemplate, bool>> Expression => (q => !string.IsNullOrEmpty(q.Name.Trim()));
    }

    public class QuizTemplateQuestionsSpecification : Specification<QuizTemplate>
    {
        public override Expression<Func<QuizTemplate, bool>> Expression => (q => q.Status== ETemplateStatus.Visible && q.Questions.Count > 1);
    }
}
