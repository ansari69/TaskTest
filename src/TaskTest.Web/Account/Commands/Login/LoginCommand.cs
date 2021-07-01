using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Web.Account.Commands.Login
{
    public class LoginCommand : IRequest<LoginVM>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
