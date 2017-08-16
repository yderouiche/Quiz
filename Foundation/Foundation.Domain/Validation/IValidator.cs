using System.Collections.Generic;
using Foundation.Utilities.Errors;
using Foundation.Utilities.Functional;

namespace Foundation.Domain.Validation
{
    public interface IValidator<T>
    {
        Either<IList<Error>, T> Validate(T entity);
    }
}
