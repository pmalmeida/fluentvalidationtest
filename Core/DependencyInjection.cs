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
