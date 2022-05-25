# Simple Example FluentValidation using .NET 6



## `PersonValidator.cs` : Validation Rules
```csharp
using FluentValidation;

namespace Core.Validators
{
    public class PersonValidator : AbstractValidator<Models.Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithName("Nome");
            RuleFor(p => p.Age).GreaterThan(18).LessThan(100).NotNull().WithName("Idade");
        }
    }
}
```


## `DependencyInjection.cs` Dependency Injection
```csharp
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            FluentValidation.ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-PT");
            services.AddControllers()
                    .AddFluentValidation(fv =>
                    {
                        // Validate child properties and root collection elements
                        fv.ImplicitlyValidateChildProperties = true;
                        fv.ImplicitlyValidateRootCollectionElements = true;
                        // Automatic registration of validators in assembly
                        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    });

            return services;
        }
    }
}
```

## `Program.cs`
```csharp
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
```
