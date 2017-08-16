using Foundation.Application.Handlers;
using Quiz.Application.Ports.Commands;
using Quiz.Domain.Entities;
using Quiz.Domain.Repositories;
using System;

namespace Quiz.Application.Ports.Handlers
{
    public class AddQuestionCommandHandler: AddCommandHandlerBase<AddQuestionCommand,Question>
    {
        public AddQuestionCommandHandler(IQuestionRepository repoistory) : base(repoistory)
        {

        }

        public string Text { get; set; }

        public Int32 QuestionType { get; set; }

        public Int32 Level { get; set; }      

        public int? Grade { get; set; }


        protected override Question CreateEntity(AddQuestionCommand command)
        {
            return new Question { Text = this.Text, QuestionType = (EQuestionType)this.QuestionType, Level = this.Level, Grade = this.Grade };
        }
    }
}
