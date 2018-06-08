using AutoMapper;
using Db.Dto;
using T034.ViewModel;

namespace T034.Profiles
{
    public class GuestBookItemProfile : Profile
    {
        public GuestBookItemProfile()
        {
            CreateMap<GuestBookItemDto, GuestBookItemViewModel>();
            CreateMap<GuestBookItemViewModel, GuestBookItemDto>();
            CreateMap<GuestBookItemViewModel, SendMessageDto>();
        }
    }
}