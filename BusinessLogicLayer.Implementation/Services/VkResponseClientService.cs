using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using DataAccessLayer.Models.Entities;
using Microsoft.Extensions.Configuration;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace BusinessLogicLayer.Implementation.Services
{
    public class VkResponseClientService : IResponseClient
    {
        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;

        private readonly ICurrencyProvider _currencyProviderService;

        public VkResponseClientService(IVkApi vkApi, IConfiguration configuration,
            ICurrencyProvider currencyProviderService)
        {
            _vkApi = vkApi;
            _configuration = configuration;
            _currencyProviderService = currencyProviderService;
        }

        public async Task<string> SendMessage(Updates updates)
        {
            // Проверяем, что находится в поле "type" 

            switch (updates.Type)
            {
                // Если это уведомление для подтверждения адреса
                case "confirmation":
                    // Отправляем строку для подтверждения 
                    return _configuration["Config:Confirmation"];

                case "message_new":
                {
                    // Десериализация
                    var msg = Message.FromJson(new VkResponse(updates.Object));

                    // Отправим в ответ полученный от пользователя текст
                    IEnumerable<CurrencyDataResponse> currencies = await _currencyProviderService.GetAnswerAsync();

                    StringBuilder message = new StringBuilder(String.Empty);

                    foreach (CurrencyDataResponse currencyData in currencies)
                    {
                        message.Append($"{currencyData.Name}: {currencyData.Value} ₽\n");
                    }

                    if (msg.PeerId != null)
                    {
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,

                            PeerId = msg.PeerId.Value,

                            Message = message.ToString()
                        });
                    }

                    break;
                }
            }

            return string.Empty;
        }
    }
}