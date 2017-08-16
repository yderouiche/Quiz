using System.Collections.Generic;
using System.Linq;
using Foundation.Utilities.Errors;
using Foundation.Utilities.Functional;

namespace Foundation.Domain.Specification
{
    public static class SpecificationExtension
    {
        public static Either<IList<Error>, R> ApplySpecifications<R>(this Either<IList<Error>, R> either, IEnumerable<ISpecificationDispacher<R>> specifications)
        {

            return either.Match< Either<IList<Error>, R>>(Left: err =>err.ToList(),
                                                          Right : value => {
                                                                              var errors = specifications.Where(spec => !spec.IsSatisfiedBy(value))
                                                                                                         .Select(x => F.Error(x.ErrorMessage))
                                                                                                         .ToList();
                                                                                if (errors.Any())
                                                                                    return errors;
                                                                                else return 
                                                                                    value;
                                                   });
        }
    }
}
