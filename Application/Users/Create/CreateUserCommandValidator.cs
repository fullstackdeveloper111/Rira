using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Family)
                .NotEmpty().WithMessage("Family is required.")
                .MaximumLength(50).WithMessage("Family must not exceed 50 characters.");

            RuleFor(x => x.NationalCode)
                .NotEmpty().WithMessage("National Code is required.")
                .Length(10).WithMessage("National Code must be 10 digits.")
                .Matches("^[0-9]+$").WithMessage("National Code must contain only digits.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        }
    }
}
