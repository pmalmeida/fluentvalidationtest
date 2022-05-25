using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation(); //Inject FluentValidation Settings
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("swagger/v1/swagger.json", "Api Teste FluentValidation"); c.RoutePrefix = string.Empty; });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
