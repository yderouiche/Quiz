using Foundation.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class Question:EntityBase
    {
        public string Text { get; set; }

        public EQuestionType QuestionType { get; set; }

        public Int32 Level { get; set; }

        public IList<Answer> Answers { get; set; }

       public int? Grade { get; set; }
    }

}
