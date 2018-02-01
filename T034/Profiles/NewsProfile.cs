﻿using System.Web;
using AutoMapper;
using Db.Dto;
using Db.Entity;
using Db.Entity.Administration;
using T034.ViewModel;

namespace T034.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            //это должно убраться отсюда
            //========
            CreateMap<News, NewsViewModel>()
                  .ForMember(dest => dest.Body, opt => opt.MapFrom(src => HttpUtility.HtmlDecode(src.Body)))
                  .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                  .ForMember(dest => dest.NewslineId, opt => opt.MapFrom(src => src.Newsline.Id))
                  .ForMember(dest => dest.Newsline, opt => opt.MapFrom(src => src.Newsline.Name));

            CreateMap<NewsViewModel, News>()
                //.ForMember(dest => dest.Body, opt => opt.MapFrom(src => AutoMapperWebConfiguration.GetSafeHtml(src.Body)))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User { Id = src.UserId }))
                .ForMember(dest => dest.Newsline, opt => opt.MapFrom(src => new Newsline { Id = src.NewslineId }));
            //=========




            CreateMap<NewsDto, NewsViewModel>();
            CreateMap<NewsViewModel, NewsDto>();
        }
    }
}