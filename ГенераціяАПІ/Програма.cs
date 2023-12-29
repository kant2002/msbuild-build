var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var описи = new[]
{
    "Freezing", "Bracing", "Холодно", "Прохолодно", "Mild", "Тепло", "М'яко", "Гаряче", "Спекотно", "Пекуче"
};

app.MapGet("/weatherforecast", () =>
{
    var прогноз = Enumerable.Range(1, 5).Select(index =>
        new ПрогнозПогоди
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            описи[Random.Shared.Next(описи.Length)]
        ))
        .ToArray();
    return прогноз;
})
.WithName("ВзятиПрогнозПогоди")
.WithOpenApi();

app.Run();

internal record ПрогнозПогоди(DateOnly Дата, int ТемператураЦ, string? Опис)
{
    public int ТемператураФ => 32 + (int)(ТемператураЦ / 0.5556);
}
