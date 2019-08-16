using System.Threading.Tasks;
using Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using DataAccessLayer.Models.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using Xunit;

namespace BusinessLogicLayer.Tests
{
    public class VkResponseClientServiceTests
    {
        Mock<IVkApi> iVkApi = new Mock<IVkApi>();
        Mock<IConfiguration> iConfiguration = new Mock<IConfiguration>();
        Mock<ICurrencyProvider> iCurrencyProvider = new Mock<ICurrencyProvider>();

        [Fact]
        public async Task SendMessage_case1()
        {
            //Arrange

            Updates updates = new Updates
            {
                Type = "confirmation"
            };

            const string confirmationMessage = "uhyuhu";

            iConfiguration.SetupGet(configuration => configuration[It.IsAny<string>()])
                .Returns(confirmationMessage);

            var vkResponseClientService = new VkResponseClientService(iVkApi.Object,
                iConfiguration.Object, iCurrencyProvider.Object);

            //Act

            var actualResult = await vkResponseClientService.SendResponse(updates);

            //Assert

            Assert.Equal(actualResult, confirmationMessage);
        }

        [Fact]
        public async Task SendMessageNull()
        {
            //Arrange

            Updates updates = null;

            var vkResponseClientService = new VkResponseClientService(iVkApi.Object,
                iConfiguration.Object, iCurrencyProvider.Object);

            //Act

            var actualResult = await vkResponseClientService.SendResponse(updates);

            //Assert

            Assert.Equal(string.Empty, actualResult);
        }

        [Fact]
        public async Task SendMessage_case2()
        {
            //Arrange

            Updates updates = new Updates
            {
                Type = "message_new",
                Object = new JObject()
            };

            //iVkApi.SetupGet(iVkApi => iVkApi[It.IsAny<string>()]).Returns();

            CurrencyExchangeRate[] currencyExchangeRates =
            {
                new CurrencyExchangeRate
                {
                    Name = "ggg",
                    Value = 2.4
                },
                new CurrencyExchangeRate
                {
                    Name = "qqq",
                    Value = 2.4
                },
                new CurrencyExchangeRate
                {
                    Name = "aaa",
                    Value = 2.4
                }
            };

            iCurrencyProvider.Setup(currencyProvider => currencyProvider.GetExchangeRateAsync()).ReturnsAsync(
                currencyExchangeRates);


            string expectedResult =
                $"{currencyExchangeRates[0].Name}: {currencyExchangeRates[0].Value} ₽\n{currencyExchangeRates[1].Name}: {currencyExchangeRates[1].Value} ₽\n{currencyExchangeRates[2].Name}: {currencyExchangeRates[2].Value} ₽\n";

            var vkResponseClientService = new VkResponseClientService(iVkApi.Object,
                iConfiguration.Object, iCurrencyProvider.Object);

            //Act

            string actualResult = await vkResponseClientService.SendResponse(updates);


            //Assert

            Assert.Equal(expectedResult, actualResult);
        }
    }
}