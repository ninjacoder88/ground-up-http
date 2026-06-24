using GroundUpHttp.Interfaces;

namespace GroundUpHttp.Internal;

internal sealed class InternalServiceCollection : IServiceCollection
{
    public void AddScoped<TInterface, TInstance>()
    {
    }

    public void AddSingleton<TInstance>()
    {
    }

    public void AddTransient<TInterface, TInstance>()
    {   
    }
}