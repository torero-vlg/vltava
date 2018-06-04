using AutoMapper;
using Db.Dto;
using Db.Entity;

namespace Db.Profiles
{
    public class GuestBookItemProfile : Profile
    {
        public GuestBookItemProfile()
        {
            CreateMap<GuestBookItem, GuestBookItemDto>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.Parent == null ? null : (int?)src.Parent.Id))
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent == null ? "" : src.Parent.ToString()));

            CreateMap<GuestBookItemDto, GuestBookItem>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.ParentId.HasValue ? new GuestBookItem { Id = src.ParentId.Value } : null));
        }
    }
}