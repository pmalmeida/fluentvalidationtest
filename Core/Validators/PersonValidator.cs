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
