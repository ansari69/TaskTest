using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Users.Command.UpsertUser
{
    public class UpserUserCommandValidator
    : AbstractValidator<UpserUserCommand>
    {
        public UpserUserCommandValidator()
        {


            RuleFor(e => e.UserName)
                .NotNull().NotEmpty()
                .When(e => e.UserId == null)
                .MaximumLength(50);

            RuleFor(e => e.Password)
                .NotNull().NotEmpty()
                .When(e => e.UserId == null)
                .MaximumLength(32);

            RuleFor(c => c.ConfirmPassword)
              .NotNull().NotEmpty()
              .When(e => e.UserId == null)
              .Equal(c => c.Password);

            RuleFor(e => e.FirstName)
                .NotNull().NotEmpty()
                .When(e => e.UserId == null);

            RuleFor(e => e.LastName)
                .NotNull().NotEmpty()
                .When(e => e.UserId == null);


        }
    }
}
