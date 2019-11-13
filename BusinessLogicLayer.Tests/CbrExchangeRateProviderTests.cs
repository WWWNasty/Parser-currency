using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Objects.Dtos.Cbr;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Models.MapperProfiles;
using Flurl.Http.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace BusinessLogicLayer.Tests
{
    public class CbrExchangeRateProviderTests : IDisposable
    {
        Mock<IConfiguration> iConfiguration = new Mock<IConfiguration>();

        public void Dispose()
        {
            _httpTest?.Dispose();
        }

        IMapper mapper =
            new Mapper(new MapperConfiguration(config => config.AddProfile(new ExchangeRateMappingProfile())));

        private HttpTest _httpTest;

        public CbrExchangeRateProviderTests()
        {
            _httpTest = new HttpTest();
        }

        [Fact]
        public async Task GetAnswerAsync_cbr()
        {
            //Arrange

//            _httpTest.RespondWith("{   \"Date\": \"2019-08-14T11:30:00+03:00\",\n    \"PreviousDate\": \"2019-08-13T11:30:00+03:00\",\n    \"PreviousURL\": \"\\/\\/www.cbr-xml-daily.ru\\/archive\\/2019\\/08\\/13\\/daily_json.js\",\n    \"Timestamp\": \"2019-08-13T23:00:00+03:00\",\n    \"Valute\": {\n       " +
//                                  "\"EUR\": {\n            \"ID\": \"R01010\",\n            \"NumCode\": \"036\",\n            \"CharCode\": \"EUR\",\n            \"Nominal\": 1,\n            \"Name\": \"Австралийский доллар\",\n            \"Value\": 44.3664,\n            \"Previous\": 44.2756\n        },\n        " +
//                                  " \"UAH\": {\n            \"ID\": \"R01020A\",\n           \"NumCode\": \"944\",\n            \"CharCode\": \"UAH\",\n            \"Nominal\": 1,\n            \"Name\": \"Азербайджанский манат\",\n            \"Value\": 38.6688,\n            \"Previous\": 38.5669\n        },\n       " +
//                                  "  \"USD\": {\n            \"ID\": \"R01035\",\n            \"NumCode\": \"826\",\n            \"CharCode\": \"USD\",\n            \"Nominal\": 1,\n            \"Name\": \"Фунт стерлингов Соединенного королевства\",\n            \"Value\": 79.1091,\n            \"Previous\": 78.9005\n        }}}");
//            
            iConfiguration.SetupGet(configuration => configuration[It.IsAny<string>()])
                .Returns("http://a.com");

            _httpTest.RespondWithJson(new CbrResponse
            {
                Date = DateTime.MinValue,
                PreviousDate = DateTime.MinValue.AddDays(1),
                Currencies = new CbrCurrencies
                {
                    EUR = new Currency
                    {
                        ID = "R01010",
                        NumCode = "036",
                        CharCode = "EUR",
                        Nominal = 1,
                        Name = "Австралийский доллар",
                        Value = 44.3664,
                        Previous = 44.2756
                    },
                    UAH = new Currency
                    {
                        ID = "R01020A",
                        NumCode = "944",
                        CharCode = "UAH",
                        Nominal = 1,
                        Name = "Азербайджанский манат",
                        Value = 38.6688,
                        Previous = 38.5669
                    },
                    USD = new Currency
                    {
                        ID = "R01035",
                        NumCode = "826",
                        CharCode = "USD",
                        Nominal = 1,
                        Name = "Фунт стерлингов Соединенного королевства",
                        Value = 79.1091,
                        Previous = 78.900
                    }
                }
            });

            var cbrCurrencyProviderService = new CbrExchangeRateProvider(mapper, iConfiguration.Object);

            CurrencyExchangeRate[] currencyExchangeRates =
            {
                new CurrencyExchangeRate
                {
                    DataSource = SourceType.Official,
                    Code = "EUR",
                    Name = "Австралийский доллар",
                    Value = 44.3664,
                    Date = DateTime.MinValue
                },
                new CurrencyExchangeRate
                {
                    DataSource = SourceType.Official,
                    Code = "UAH",
                    Name = "Азербайджанский манат",
                    Value = 38.6688,
                    Date = DateTime.MinValue
                },
                new CurrencyExchangeRate
                {
                    DataSource = SourceType.Official,
                    Code = "USD",
                    Name = "Фунт стерлингов Соединенного королевства",
                    Value = 79.1091,
                    Date = DateTime.MinValue
                }
            };

            //Act

            var actualResult = await cbrCurrencyProviderService.GetExchangeRateAsync();

            //Assert

            Assert.Equal(currencyExchangeRates, actualResult, new JsonSerializedComparer<CurrencyExchangeRate>());
        }
    }
}