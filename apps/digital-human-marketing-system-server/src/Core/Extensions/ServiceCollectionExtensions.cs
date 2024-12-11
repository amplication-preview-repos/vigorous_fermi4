using .APIs;

namespace ;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBusinessAccountsService, BusinessAccountsService>();
        services.AddScoped<IDigitalHumenService, DigitalHumenService>();
        services.AddScoped<IDigitalHumanKnowledgeBasesService, DigitalHumanKnowledgeBasesService>();
        services.AddScoped<IDigitalHumanStatsService, DigitalHumanStatsService>();
        services.AddScoped<IMarketingProductsService, MarketingProductsService>();
        services.AddScoped<IVoiceTonesService, VoiceTonesService>();
    }

}
