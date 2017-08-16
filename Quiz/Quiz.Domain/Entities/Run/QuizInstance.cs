using Foundation.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class QuizInstance: EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public Decimal Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal RequiredSuccessRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EQuizStatus QuestionStatus { get; set; }= EQuizStatus.Created;


        /// <summary>
        /// 
        /// </summary>
        public bool IsPredefined
        {
            get { return Template != null; }
        }

        /// <summary>
        /// 
        /// </summary>
        public QuizTemplate Template { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        private IList<Question> _Questions;
        public IList<Question> Questions
        {
            get { return (Template != null) ? Template.Questions : _Questions; }            
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<QuizRun> QuizRun { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questions"></param>
        public QuizInstance(IList<Question> questions)
        {
            _Questions = questions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        public QuizInstance(QuizTemplate template)
        {
            Template = template;
            RequiredSuccessRate = template.RequiredSuccessRate;
        }

    }

    
}
