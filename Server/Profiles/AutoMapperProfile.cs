using AutoMapper;
using Infrastructure.HrModels;
using Server.Features.Departments.GetDepartments;


namespace Server.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdminEntity, GetDepartmentsQueryResponse>().ReverseMap();

        }
    }
}
