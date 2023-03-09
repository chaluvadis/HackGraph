using Azure.Identity;
using Microsoft.Graph;

var scopes = new[] { "User.Read" };
var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
{
    ClientId = "811cecb2-1cef-45f3-845d-942914cee31e"
};
var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

var graphClient = new GraphServiceClient(tokenCredential, scopes);

var me = await graphClient.Me.GetAsync();
Console.WriteLine($"Hello {me?.DisplayName}!");
