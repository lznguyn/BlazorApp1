using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Data;
using BlazorApp1.models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BlazorWebAppMoviesContext") ?? throw new InvalidOperationException("Connection string 'BlazorWebAppMoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Register MongoDbConfig using environment variables with IOptions
builder.Services.Configure<MongoDbConfig>(options =>
{
    options.ConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING") ?? string.Empty;
    options.DatabaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME") ?? string.Empty;
});

// Register MongoDbContext as a singleton or scoped service
builder.Services.AddSingleton<MongoDbContext>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
