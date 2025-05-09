using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using SggApp.API.Contextos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Agregar DbContext con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<SggAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/", async (HttpContext http, IRazorViewEngine viewEngine,
                       ITempDataProvider tempDataProvider, IServiceProvider serviceProvider) =>
{
    var actionContext = new ActionContext(http, http.GetRouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

    var viewResult = viewEngine.FindView(actionContext, "Usuario/Index", false);

    if (!viewResult.Success)
    {
        throw new InvalidOperationException($"No se pudo encontrar la vista 'Index'.");
    }

    using var sw = new StringWriter();
    var viewDictionary = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
    {
        Model = null // Puedes pasar un modelo aquí si deseas
    };

    var tempData = new TempDataDictionary(http, tempDataProvider);
    var viewContext = new ViewContext(
        actionContext,
        viewResult.View,
        viewDictionary,
        tempData,
        sw,
        new HtmlHelperOptions()
    );

    await viewResult.View.RenderAsync(viewContext);
    return Results.Content(sw.ToString(), "text/html");
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
