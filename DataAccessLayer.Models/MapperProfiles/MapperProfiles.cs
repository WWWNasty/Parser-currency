using System;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //opt => opt.MapFrom(dto => dto.SubCategory.Id)
            //cbr resp в мою х у й н ю (отправка пльзователю ответа)
            CreateMap<Currency, CurrencyDataResponse>()
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

    public class DateResolver : IValueResolver<Currency, CurrencyDataResponse, DateTime>
    {
        public DateTime Resolve(Currency source, CurrencyDataResponse destination, DateTime destMember,
            ResolutionContext context) =>
            context.Items["Date"] as DateTime? ?? DateTime.Today;
    }
}