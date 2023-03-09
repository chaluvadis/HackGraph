using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var config = builder.Build();
var azureId = config.GetSection("AzureAd").Get<AzureAd>();
var downStreamApi = config.GetSection("DownstreamApi").Get<DownstreamApi>();

var scopes = downStreamApi.Scopes.Split(' ');
var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
{
    ClientId = azureId.ClientId,
    TenantId = azureId.TenantId,
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
    RedirectUri = new Uri(azureId.RedirectUri)
};

var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

var graphClient = new GraphServiceClient(tokenCredential, scopes);

var me = await graphClient.Me.GetAsync();
Console.WriteLine($"Hello {me?.DisplayName}!");

public record AzureAd
(
    string Instance,
    string Domain,
    string TenantId,
    string ClientId,
    string CallbackPath,
    string Scopes,
    string RedirectUri
);

public record DownstreamApi
(
    string BaseUrl,
    string Scopes
);