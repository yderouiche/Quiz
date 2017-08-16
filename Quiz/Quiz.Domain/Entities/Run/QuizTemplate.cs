using Foundation.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class QuizTemplate:EntityBase
    {
        public string Name { get; set; }

        public ETemplateStatus Status { get; set; } = ETemplateStatus.hidden;

        public Decimal RequiredSuccessRate { get; set; }

        public IList<Question> Questions { get; set; }
    }


}
