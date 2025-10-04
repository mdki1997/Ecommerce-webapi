var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var response = new { message = "This is json object", success = true };
    return response;
});

var products = new List<Product>() {
    new Product("Samsung s20", 1250),
    new Product("Apple iphone 16", 1367)
};
app.MapGet("/products", () =>
{
    return Results.Ok(products);
});


app.Run();

public record Product(string Name, decimal Price);