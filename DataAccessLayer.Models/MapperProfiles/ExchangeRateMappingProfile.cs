using AutoMapper;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models.MapperProfiles
{
    public class ExchangeRateMappingProfile : Profile
    {
        public ExchangeRateMappingProfile()
        {
            CreateMap<Currency, CurrencyExchangeRate>()
                .ForMember(dest => dest.Date, options => options
                    .MapFrom<DateResolver>())
                .ForMember(dest => dest.DataSource, options => options
                    .MapFrom(dto => SourceType.Official))
                .ForMember(dest => dest.Code, options => options
                    .MapFrom(dto => dto.CharCode))
                .ForMember(dest => dest.Value, options => options
                    .MapFrom(dto => dto.Value / dto.Nominal));
        }
    }
}