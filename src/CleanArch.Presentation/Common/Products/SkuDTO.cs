namespace CleanArch.Presentation.Common.Products;

public record SkuDTO
{
    private const int DefaultLength = 15;
    private SkuDTO(string value) =>  Value = value;
    public string Value { get; init; }
    
    public static SkuDTO Create(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            return null;
        }      

        // if(value.Length != DefaultLength)
        // {
        //     return null;
        // }

        return new SkuDTO(value);
    }

}