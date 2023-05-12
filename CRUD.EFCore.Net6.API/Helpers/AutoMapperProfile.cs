using AutoMapper;
using CRUD.EFCore.Net6.API.Entities;
using CRUD.EFCore.Net6.API.Models.Users;

namespace CRUD.EFCore.Net6.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateUser -> User
            CreateMap<CreateUser, User>();

            // UpdateUser -> User
            CreateMap<UpdateUser, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }
    }
}
