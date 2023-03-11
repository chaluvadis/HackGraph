namespace HackGraph.Client;
public static class GraphClient
{
    public static IServiceCollection ConfigureGraphClient(this IServiceCollection services, IConfiguration configuration)
    {
        var azureAd = configuration.GetSection("AzureAd").Get<AzureAd>();
        var downStreamApi = configuration.GetSection("DownstreamApi").Get<DownstreamApi>();
        var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
        {
            ClientId = azureAd.ClientId,
            TenantId = azureAd.TenantId,
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            RedirectUri = new Uri(azureAd.RedirectUri)
        };
        var scopes = downStreamApi.Scopes.Split(' ');
        var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);
        services.AddScoped(_ => new GraphServiceClient(tokenCredential, scopes));
        return services;
    }
}