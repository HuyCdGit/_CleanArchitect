using CleanArch.Domain.Host.ValueObjects;

namespace CleanArch.Application.UnitTests.TestUtils.Constants;
public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.Create("Host Id"); 
    }
}