using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTest.Web.Identity;

namespace TaskTest.Web.Users.Command.UpsertUser
{
    public class UpserUserCommandHandler
        : IRequestHandler<UpserUserCommand, UpsertUserVM>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;


        public UpserUserCommandHandler(UserManager<ApplicationUser> userManager,
             RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<UpsertUserVM> Handle(UpserUserCommand request,
          CancellationToken cancellationToken)
        {


            var user = new ApplicationUser();

            if (request.UserId == null)
            {
                if (request.UserName == null || request.Password == null)
                    throw new Exception("");

                user.UserName = request.UserName;
                user.CreateDate = DateTime.Now;
                var createResult = await _userManager.CreateAsync(user, request.Password);

                if (!createResult.Succeeded)
                    throw new Exception("");
            }
            else
            {
                user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                    throw new Exception("");
            }



            user = _mapper.Map<UpserUserCommand, ApplicationUser>(request, user);



            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                throw new Exception("");



            //if (request.Password != null && request.UserId != null)
            //{
            //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //    var passResult = await _userManager.ResetPasswordAsync(user, token, request.Password);
            //    if (!passResult.Succeeded)
            //        throw new Exception("");
            //}


            return new UpsertUserVM() { UserId = user.Id };
        }

    }
}
