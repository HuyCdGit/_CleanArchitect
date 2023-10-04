namespace CleanArch.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Product
    {
        public const string Name = "huytest";
        public const string Sku = "huy";
        public const string Currency = "VND";
        public const decimal Amount = 1000;

        public static string ProductNameFromIndex(int index) => $"{Name} {index}";
        public static string ProductSkuFromIndex(int index) => $"{Sku} {index}";
        public static string ProductCurrencyFromIndex(int index) => $"{Currency} {index}";
        public static string ProductAmountFromIndex(int index) => $"{Amount} {index}";
         
    }
}