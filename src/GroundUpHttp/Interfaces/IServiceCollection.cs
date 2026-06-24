namespace GroundUpHttp.Internal;

public interface IServiceCollection
{
    void AddScoped<TInterface, TInstance>();
    void AddSingleton<TInstance>();
    void AddTransient<TInterface, TInstance>();
}