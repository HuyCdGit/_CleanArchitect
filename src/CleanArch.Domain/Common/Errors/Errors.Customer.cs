using ErrorOr;

namespace CleanArch.Domain.Common.Errors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "User. DuplicateEmail",
            description: "Email is alread in use.");
    }
}