using AuthChallenge.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<TokenValidationMiddleware>();
app.UseHttpsRedirection();

app.MapGet("/foo-bar", () => Results.NoContent());

app.Run();