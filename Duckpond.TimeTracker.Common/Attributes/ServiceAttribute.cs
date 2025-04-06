namespace Duckpond.TimeTracker.Common.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ServiceAttribute : Attribute
{
    public ServiceLifetime ServiceLifetime { get; private set; }
    public object? ServiceKey { get; private set; }
    public ServiceAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, object? serviceKey = null)
    {
        ServiceLifetime = serviceLifetime;
        ServiceKey = serviceKey;
    }
}