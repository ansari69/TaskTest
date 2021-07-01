using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTest.Web.Identity;
using TaskTest.Web.Users.Command.UpsertUser;

namespace TaskTest.Web.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Upsert
            CreateMap<UpserUserCommand, ApplicationUser>()
                .ForAllMembers(opt => opt.Condition((src, dist, srcMember) => srcMember != null));
        }
    }
}
