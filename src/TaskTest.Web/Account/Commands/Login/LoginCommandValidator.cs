using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Account.Commands.Login
{
    public class LoginCommandValidator
        : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(m => m.Username)
               .NotNull()
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(m => m.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
