namespace GroundUpHttp.Interfaces;

public interface IServiceCollection
{
    void AddScoped<TInterface, TInstance>();
    void AddSingleton<TInstance>();
    void AddTransient<TInterface, TInstance>();

    TInterface? GetService<TInterface>();
    TInterface GetRequiredService<TInterface>();
}