using AutoMapper;
using Domain.Models;
using WebApi.ViewModels;

namespace WebApi.Mapping
{
    public sealed class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<PhotoCard, PhotoCardVM>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail))
                .MaxDepth(1);

            CreateMap<PhotoCardVM, PhotoCard>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail))
                .MaxDepth(1);
        }
    }
}
