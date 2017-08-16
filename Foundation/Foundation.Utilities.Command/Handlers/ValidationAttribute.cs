using Paramore.Brighter;
using System;

namespace Foundation.Application.Handlers
{
    public class ValidationAttribute : RequestHandlerAttribute
    {
        public ValidationAttribute(int step, HandlerTiming timing)
            : base(step, timing)
        { }

        public override Type GetHandlerType()
        {
            return typeof(ValidationHandler<>);
        }
    }
}
