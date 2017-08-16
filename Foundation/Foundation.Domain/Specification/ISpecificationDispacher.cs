using NSpecifications;
using System.Collections.Generic;

namespace Foundation.Domain.Specification
{
    public interface ISpecificationDispacher<T> : ISpecification<T>
    {
        string ErrorMessage { get; }

        IList<EnumAction> Actions { get; }
       
    }


    public enum EnumAction
    {
        Creation,
        Modification,
        Deletion
    }
}
