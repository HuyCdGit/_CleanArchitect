using CleanArch.Application.Common.Customers;
using CleanArch.Presentation.Common.Products;
using Mapster;

namespace CleanArch.Api.Mapping;

public sealed class CustomerMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerResult, CustomerResponse>()
        .Map(d => d, e => e.Customer);
    }
}