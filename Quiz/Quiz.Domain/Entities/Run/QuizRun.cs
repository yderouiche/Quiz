using Foundation.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class QuizRun:EntityBase
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string UserName { get; set; }

        public IList<QuizAnswers> UserAnswers { get; set; }
    }
}
