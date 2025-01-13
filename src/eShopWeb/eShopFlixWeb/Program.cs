using eShopFlixWeb.Clients;
using eShopFlixWeb.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddOptions();
builder.Services.Configure<BackendGatewayOption>(builder.Configuration.GetSection("BackendGateway"));

/*Configure http client for api gatteway*/
builder.Services.AddHttpClient("Gateway")
    .ConfigureHttpClient((c, client) =>
    {
        var options = c.GetRequiredService<IOptions<BackendGatewayOption>>();
        client.BaseAddress = new Uri(options.Value.GatewayAddress);
        client.Timeout = TimeSpan.FromMinutes(5);
    });

builder.Services.AddHttpClient<AuthenticationServiceClient>("Gateway");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
