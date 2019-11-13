using System;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.MapperProfiles
{
    public class DateResolver : IValueResolver<Currency, CurrencyExchangeRate, DateTime>
    {
        public DateTime Resolve(Currency source, CurrencyExchangeRate destination, DateTime destMember,
            ResolutionContext context) =>
            context.Items[CbrConstants.Date] as DateTime? ?? DateTime.Today;
    }
}