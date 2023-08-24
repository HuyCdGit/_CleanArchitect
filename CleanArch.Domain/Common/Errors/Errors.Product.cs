using ErrorOr;

namespace CleanArch.Domain.Common.Errors;

public static class Errors
{
    public static class Product 
    {
        public static Error DuplicateProduct => Error.Conflict(
            code: "Product.Duplicate",
            description: "The product has been exist"
        );
    }
}