using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Commands.LoginCommand
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email address is required.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
