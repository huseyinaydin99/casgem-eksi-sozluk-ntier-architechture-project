using AutoMapper;
using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Models;

namespace EksiSozluk.PresentationLayer.Mappers
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
        }
    }
}