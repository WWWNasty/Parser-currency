using System.Collections.Generic;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos;
using DataAccessLayer.Models.Entities;
using Flurl.Http;

namespace BusinessLogicLayer.Implementation.Services
{
    public class CbrCurrencyProviderService : ICurrencyProvider
    {
        private readonly IMapper _mapper;

        public CbrCurrencyProviderService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyDataResponse>> GetAnswerAsync()
        {
            CbrResponse cbrResponse = await "https://www.cbr-xml-daily.ru/daily_json.js".GetJsonAsync<CbrResponse>();

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
            return _mapper.Map<IEnumerable<CurrencyDataResponse>>(currencies,
                options => options.Items["Date"] = cbrResponse.Date);
        }
    }
}