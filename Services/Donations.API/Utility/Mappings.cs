using AutoMapper;
using Donations.API.Models;
using Donations.API.Models.Data;

namespace Donations.API.Utility
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>()
                .ForMember(dest => dest.DateCreated, o => o.Ignore())
                .ForMember(dest => dest.DateModified, o => o.Ignore())
                .ReverseMap();
        }
    }
}