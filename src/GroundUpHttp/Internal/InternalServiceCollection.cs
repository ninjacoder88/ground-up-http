using GroundUpHttp.Interfaces;

namespace GroundUpHttp.Internal;

internal sealed class InternalServiceCollection : IServiceCollection
{
    public void AddScoped<TInterface, TInstance>()
    {
        _lookup.Add(typeof(TInterface), typeof(TInstance));
    }

    public void AddSingleton<TInstance>()
    {
    }

    public void AddTransient<TInterface, TInstance>()
    {   
    }

    public TInterface? GetService<TInterface>()
    {
        Type iType = typeof(TInterface);
        if(!_lookup.TryGetValue(iType, out Type? tType))
            return default;
        return (TInterface)Activator.CreateInstance(tType);
    }

    public TInterface GetRequiredService<TInterface>()
    {
        Type iType = typeof(TInterface);
        if(!_lookup.TryGetValue(iType, out Type? tType))
            throw new Exception($"no type registered for {iType.Name}");
        return (TInterface)Activator.CreateInstance(tType);
    }

    private Dictionary<Type, Type> _lookup = [];
}