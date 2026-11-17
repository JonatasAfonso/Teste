using System.Net;
using Recrutamento.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<CandidateStore>();

var app = builder.Build();
app.Services.GetRequiredService<CandidateStore>().Initialize();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var address = context.Connection.RemoteIpAddress;
    if (address is null || !IPAddress.IsLoopback(address.MapToIPv6()))
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return;
    }

    context.Response.Headers.CacheControl = "no-store";
    await next();
});

app.UseHttpsRedirection();
app.UseRouting();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
app.Run();
