using AutoMapper;
using Dapper.PostgreSql.Core7.Api.Entities;
using Dapper.PostgreSql.Core7.Api.Models.Users;

namespace Dapper.PostgreSql.Core7.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src == null) return false;

                        return true;
                    }
                ));
        }
    }
}
