using ErrorOr;

namespace CleanArch.Domain.Common.Errors;

public static partial class Errors
{
    public static class Order
    {
        public static Error Duplicate => Error.Conflict
        (
            code : "Order.Duplicate",
            description: "The order has been exist"
        );
    }
}   