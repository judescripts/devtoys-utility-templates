using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using tab.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// TODO: Make sure to add the AKV Url in appsettings.Development.json or remove service if it's not needed
var keyVaultEndpointString = builder.Configuration["AzureKeyVault:Url"];
var keyVaultEndpoint = !string.IsNullOrEmpty(keyVaultEndpointString) ? new Uri(keyVaultEndpointString) : null;

var options = new SecretClientOptions()
{
    Retry =
    {
        Delay = TimeSpan.FromSeconds(2),
        MaxDelay = TimeSpan.FromSeconds(16),
        MaxRetries = 5,
        Mode = RetryMode.Exponential
    }
};

builder.Services.AddScoped(sp =>
{
    var secretClient = new SecretClient(keyVaultEndpoint,  new DefaultAzureCredential(new DefaultAzureCredentialOptions
    {
        ExcludeEnvironmentCredential = false,
        ExcludeWorkloadIdentityCredential = false,
        ExcludeManagedIdentityCredential = false,
        ExcludeAzureDeveloperCliCredential = false,
        ExcludeSharedTokenCacheCredential = false,
        ExcludeInteractiveBrowserCredential = false,
        ExcludeAzureCliCredential = false,
        ExcludeVisualStudioCredential = false,
        ExcludeVisualStudioCodeCredential = false,
        ExcludeAzurePowerShellCredential = false,
        DisableInstanceDiscovery = false
    }), options);
    return secretClient;
});

// TODO: Make sure to add the connection string in appsettings.Development.json or further implement and retrieve the connection string from AKV 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
