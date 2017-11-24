using NSpecifications;
using System;
using System.Linq.Expressions;
using Quiz.Domain.Entities;

namespace Quiz.Domain.Specfication
{
	
    public class QuizDurationSpecification : Specification<QuizInstance>
    {
        public override Expression<Func<QuizInstance, bool>> Expression => (q => q.Duration>0);
    }

    public class QuizRequiredSuccessRateSpecification : Specification<QuizInstance>
    {
        public override Expression<Func<QuizInstance, bool>> Expression => (q => q.RequiredSuccessRate > 0);
    }
}
