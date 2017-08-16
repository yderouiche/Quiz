using Foundation.Domain.Entity;

namespace Quiz.Domain.Entities
{
    public class Answer: EntityBase
    {
        public string Text { get; set; }

        public bool IsRight { get; set; }
    }
}
