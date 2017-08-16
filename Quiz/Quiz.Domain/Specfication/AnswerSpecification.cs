using NSpecifications;
using Quiz.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Quiz.Domain.Specfication
{
    public class AnwserTextSpecification : Specification<Answer>
    {
        public override Expression<Func<Answer, bool>> Expression => (q => !string.IsNullOrEmpty(q.Text.Trim()));
    }

  
}
