using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskTest.Web.Common;
using TaskTest.Web.Identity;

namespace TaskTest.Web.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginVM>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IOptions<AppSettings> appSettings,
            IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
            _mediator = mediator;
        }

        public async Task<LoginVM> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var loginResult = await _signInManager.PasswordSignInAsync(request.Username,
               request.Password, true, false);


            if (loginResult.Succeeded)
            {
                //get user
                var user = await _userManager.FindByNameAsync(request.Username);

                if(user == null)
                    throw new Exception("Errore");

                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256);
                var tokenClaims = new List<Claim>()
                {
                    new Claim("Identifier", user.Id),
                    new Claim("UserName", user.UserName),
                    new Claim("FullName", user.UserName + " " + user.LastName),
                    new Claim("Rank", "")
                };

                var tokenOptions = new JwtSecurityToken(
                   claims: tokenClaims,
                   expires: DateTime.Now.AddDays(7),
                   signingCredentials: credentials
               );

                string token = tokenHandler.WriteToken(tokenOptions);

                return new LoginVM()
                {
                    Token = token
                };

            }



            throw new Exception("Errore");

        }
    }
}
