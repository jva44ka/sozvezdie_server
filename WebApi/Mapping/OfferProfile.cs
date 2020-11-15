using AutoMapper;
using Domain.Models;
using WebApi.ViewModels;

namespace WebApi.Mapping
{
    public class OfferProfile : Profile 
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => src.Header))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route))
                .ForMember(dest => dest.PeriodStart, opt => opt.MapFrom(src => src.PeriodStart))
                .ForMember(dest => dest.PeriodEnd, opt => opt.MapFrom(src => src.PeriodEnd))
                .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.MinPrice))
                .ForMember(dest => dest.PhotoCard, opt => opt.MapFrom(src => src.PhotoCard))
                .ForMember(dest => dest.PhotoAlbum, opt => opt.MapFrom(src => src.PhotoAlbum))
                .IncludeAllDerived()
                .MaxDepth(1);

            CreateMap<Offer, OfferListItemVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => src.Header))
                .ForMember(dest => dest.PeriodStart, opt => opt.MapFrom(src => src.PeriodStart))
                .ForMember(dest => dest.PeriodEnd, opt => opt.MapFrom(src => src.PeriodEnd))
                .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.MinPrice))
                .ForMember(dest => dest.PhotoCard, opt => opt.MapFrom(src => src.PhotoCard))
                .IncludeAllDerived()
                .MaxDepth(1);
        }
    }
}
