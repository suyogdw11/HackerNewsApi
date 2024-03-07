using System;
using AutoMapper;
using HackerNewsApi.Model;

namespace HackerNewsApi.Profiles{

    public class HackerNewsProfile : Profile
    {
        public HackerNewsProfile(){
            CreateMap<Story, OutputStory>()
            .ForMember(dest => dest.uri, opt => opt.MapFrom(src => src.url))
            .ForMember(dest => dest.postedBy, opt => opt.MapFrom(src => src.by))
            .ForMember(dest => dest.commentCount, opt => opt.MapFrom(src => src.descendants))
            .ForMember(dest => dest.time, opt => opt.MapFrom(src => formatDate(src.time)));
        }

        private string formatDate(long unixDate)
        {
            var dotNetDate = DateTimeOffset.FromUnixTimeSeconds(unixDate);
            return dotNetDate.LocalDateTime.ToString("yyyy-MM-ddTHH:mm:ssK");
        }
    }
}