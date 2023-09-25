// using CleanArch.Domain.Common.Models;

// namespace CleanArch.Domain.Orders.ValueObjects;

// public sealed class OrderCustomerId : ValueObject
// {
//     public Guid Value{get;}
//     private OrderCustomerId (Guid value)
//     {
//         this.Value = value;
//     }

//     public static OrderCustomerId CreateUnique() => new(Guid.NewGuid());
//     public override IEnumerable<object?> GetEqualityComponents()
//     {
//         yield return Value;
//     }
// }
