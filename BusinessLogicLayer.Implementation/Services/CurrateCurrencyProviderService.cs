using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Currate;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Enums;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Implementation.Services
{
    public class CurrateCurrencyProviderService : IUnofficialSource
    {
        private readonly IConfiguration _configuration;

        public CurrateCurrencyProviderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRateAsync()
        {
            CurrateResponse currateResponse =
                await _configuration["Config:LinqCurrate"]
                    .GetJsonAsync<CurrateResponse>();

            return new[]
            {
                new CurrencyExchangeRate
                {
                    DataSource = SourceType.Exchange,

                    Code = "EUR",

                    Date = DateTime.UtcNow,

                    Name = "Евро",

                    Value = currateResponse.Data.EURRUB
                },

                new CurrencyExchangeRate
                {
                    DataSource = SourceType.Exchange,

                    Code = "USD",

                    Date = DateTime.UtcNow,

                    Name = "Доллар США",

                    Value = currateResponse.Data.USDRUB
                }
            };
        }
    }
}