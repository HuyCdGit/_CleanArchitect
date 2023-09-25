// using CleanArch.Domain.Common.Models;

// namespace CleanArch.Domain.Orders.ValueObjects;

// public sealed class OrderId : ValueObject
// {
//     public Guid Value {get;}

//     private OrderId(Guid value)
//     {
//         this.Value = value;
//     }
//     public static OrderId CreateUnique() => new(Guid.NewGuid());
//     public override IEnumerable<object?> GetEqualityComponents()
//     {
//         yield return Value;
//     }
// }