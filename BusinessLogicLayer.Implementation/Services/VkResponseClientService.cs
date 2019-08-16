using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
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

        public async Task<string> SendResponse(Updates updates)
        {
            if (updates == null)
            {
                return string.Empty;
            }
            // Проверяем, что находится в поле "type" 

            switch (updates.Type)
            {
                // Если это уведомление для подтверждения адреса
                case VkMessagesTypes.Confirmation:
                    // Отправляем строку для подтверждения 
                    return _configuration["Config:Confirmation"];

                case VkMessagesTypes.MessageNew:
                {
                    // Десериализация
                    var vkMessage = Message.FromJson(new VkResponse(updates.Object));

                    // Отправим в ответ полученный от пользователя текст
                    IEnumerable<CurrencyExchangeRate> currencies = await _currencyProviderService
                        .GetExchangeRateAsync();

                    string responseMessage = currencies.Aggregate(string.Empty,
                        (previous, current) => previous + $"{current.Name}: {current.Value} ₽\n");

                    if (vkMessage.PeerId != null)
                    {
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,

                            PeerId = vkMessage.PeerId.Value,

                            Message = responseMessage
                        });
                    }

                    return responseMessage;
                }
            }

            return string.Empty;
        }
    }
}