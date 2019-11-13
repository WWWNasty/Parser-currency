using System.Collections.Generic;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Implementation.Services
{
    public class CbrExchangeRateProvider : IOfficialSource
    {
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public CbrExchangeRateProvider(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;

            _configuration = configuration;
        }


        public async Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRateAsync()
        {
            CbrResponse cbrResponse = await _configuration["Config:LinqCbr"]
                .GetJsonAsync<CbrResponse>();

            Currency[] currencies =
            {
                cbrResponse.Currencies.EUR,
                cbrResponse.Currencies.UAH,
                cbrResponse.Currencies.USD
            };
//
//            return currencies.Select(currency => new CurrencyDataResponse
//                {
//                    DataSource = SourceType.Official,
//                    Date = cbrResponse.Date,
//                    Code = currency.CharCode,
//                    Name = currency.Name,
//                    Value = currency.Value / currency.Nominal
//                })
//                .ToList();

            return _mapper.Map<IEnumerable<CurrencyExchangeRate>>(currencies,
                options => options.Items[CbrConstants.Date] = cbrResponse.Date);
        }
    }
}