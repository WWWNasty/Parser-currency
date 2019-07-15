﻿using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ConsoleAppCourseCurrency
{
    class Program
    {
        static async Task Main()
        {

            //string json = "{\r\n    \"Date\": \"2019-07-09T11:30:00+03:00\",\r\n    \"PreviousDate\": \"2019-07-06T11:30:00+03:00\",\r\n    \"PreviousURL\": \"\\/\\/www.cbr-xml-daily.ru\\/archive\\/2019\\/07\\/06\\/daily_json.js\",\r\n    \"Timestamp\": \"2019-07-08T14:00:00+03:00\",\r\n    \"Valute\": {\r\n        \"AUD\": {\r\n            \"ID\": \"R01010\",\r\n            \"NumCode\": \"036\",\r\n            \"CharCode\": \"AUD\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0410\u0432\u0441\u0442\u0440\u0430\u043B\u0438\u0439\u0441\u043A\u0438\u0439 \u0434\u043E\u043B\u043B\u0430\u0440\",\r\n            \"Value\": 44.6578,\r\n            \"Previous\": 44.636\r\n        },\r\n        \"AZN\": {\r\n            \"ID\": \"R01020A\",\r\n            \"NumCode\": \"944\",\r\n            \"CharCode\": \"AZN\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0410\u0437\u0435\u0440\u0431\u0430\u0439\u0434\u0436\u0430\u043D\u0441\u043A\u0438\u0439 \u043C\u0430\u043D\u0430\u0442\",\r\n            \"Value\": 37.648,\r\n            \"Previous\": 37.4796\r\n        },\r\n        \"GBP\": {\r\n            \"ID\": \"R01035\",\r\n            \"NumCode\": \"826\",\r\n            \"CharCode\": \"GBP\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0424\u0443\u043D\u0442 \u0441\u0442\u0435\u0440\u043B\u0438\u043D\u0433\u043E\u0432 \u0421\u043E\u0435\u0434\u0438\u043D\u0435\u043D\u043D\u043E\u0433\u043E \u043A\u043E\u0440\u043E\u043B\u0435\u0432\u0441\u0442\u0432\u0430\",\r\n            \"Value\": 80.0609,\r\n            \"Previous\": 79.8489\r\n        },\r\n        \"AMD\": {\r\n            \"ID\": \"R01060\",\r\n            \"NumCode\": \"051\",\r\n            \"CharCode\": \"AMD\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u0410\u0440\u043C\u044F\u043D\u0441\u043A\u0438\u0445 \u0434\u0440\u0430\u043C\u043E\u0432\",\r\n            \"Value\": 13.404,\r\n            \"Previous\": 13.3297\r\n        },\r\n        \"BYN\": {\r\n            \"ID\": \"R01090B\",\r\n            \"NumCode\": \"933\",\r\n            \"CharCode\": \"BYN\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0411\u0435\u043B\u043E\u0440\u0443\u0441\u0441\u043A\u0438\u0439 \u0440\u0443\u0431\u043B\u044C\",\r\n            \"Value\": 31.1075,\r\n            \"Previous\": 31.0454\r\n        },\r\n        \"BGN\": {\r\n            \"ID\": \"R01100\",\r\n            \"NumCode\": \"975\",\r\n            \"CharCode\": \"BGN\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0411\u043E\u043B\u0433\u0430\u0440\u0441\u043A\u0438\u0439 \u043B\u0435\u0432\",\r\n            \"Value\": 36.6794,\r\n            \"Previous\": 36.6226\r\n        },\r\n        \"BRL\": {\r\n            \"ID\": \"R01115\",\r\n            \"NumCode\": \"986\",\r\n            \"CharCode\": \"BRL\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0411\u0440\u0430\u0437\u0438\u043B\u044C\u0441\u043A\u0438\u0439 \u0440\u0435\u0430\u043B\",\r\n            \"Value\": 16.7107,\r\n            \"Previous\": 16.723\r\n        },\r\n        \"HUF\": {\r\n            \"ID\": \"R01135\",\r\n            \"NumCode\": \"348\",\r\n            \"CharCode\": \"HUF\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u0412\u0435\u043D\u0433\u0435\u0440\u0441\u043A\u0438\u0445 \u0444\u043E\u0440\u0438\u043D\u0442\u043E\u0432\",\r\n            \"Value\": 22.1087,\r\n            \"Previous\": 22.142\r\n        },\r\n        \"HKD\": {\r\n            \"ID\": \"R01200\",\r\n            \"NumCode\": \"344\",\r\n            \"CharCode\": \"HKD\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0413\u043E\u043D\u043A\u043E\u043D\u0433\u0441\u043A\u0438\u0445 \u0434\u043E\u043B\u043B\u0430\u0440\u043E\u0432\",\r\n            \"Value\": 81.9055,\r\n            \"Previous\": 81.6133\r\n        },\r\n        \"DKK\": {\r\n            \"ID\": \"R01215\",\r\n            \"NumCode\": \"208\",\r\n            \"CharCode\": \"DKK\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0414\u0430\u0442\u0441\u043A\u0438\u0445 \u043A\u0440\u043E\u043D\",\r\n            \"Value\": 96.1375,\r\n            \"Previous\": 95.9673\r\n        },\r\n        \"USD\": {\r\n            \"ID\": \"R01235\",\r\n            \"NumCode\": \"840\",\r\n            \"CharCode\": \"USD\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0414\u043E\u043B\u043B\u0430\u0440 \u0421\u0428\u0410\",\r\n            \"Value\": 63.8699,\r\n            \"Previous\": 63.5841\r\n        },\r\n        \"EUR\": {\r\n            \"ID\": \"R01239\",\r\n            \"NumCode\": \"978\",\r\n            \"CharCode\": \"EUR\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0415\u0432\u0440\u043E\",\r\n            \"Value\": 71.7067,\r\n            \"Previous\": 71.6593\r\n        },\r\n        \"INR\": {\r\n            \"ID\": \"R01270\",\r\n            \"NumCode\": \"356\",\r\n            \"CharCode\": \"INR\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u0418\u043D\u0434\u0438\u0439\u0441\u043A\u0438\u0445 \u0440\u0443\u043F\u0438\u0439\",\r\n            \"Value\": 92.9206,\r\n            \"Previous\": 92.8438\r\n        },\r\n        \"KZT\": {\r\n            \"ID\": \"R01335\",\r\n            \"NumCode\": \"398\",\r\n            \"CharCode\": \"KZT\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u041A\u0430\u0437\u0430\u0445\u0441\u0442\u0430\u043D\u0441\u043A\u0438\u0445 \u0442\u0435\u043D\u0433\u0435\",\r\n            \"Value\": 16.623,\r\n            \"Previous\": 16.5487\r\n        },\r\n        \"CAD\": {\r\n            \"ID\": \"R01350\",\r\n            \"NumCode\": \"124\",\r\n            \"CharCode\": \"CAD\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u041A\u0430\u043D\u0430\u0434\u0441\u043A\u0438\u0439 \u0434\u043E\u043B\u043B\u0430\u0440\",\r\n            \"Value\": 48.8788,\r\n            \"Previous\": 48.6675\r\n        },\r\n        \"KGS\": {\r\n            \"ID\": \"R01370\",\r\n            \"NumCode\": \"417\",\r\n            \"CharCode\": \"KGS\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u041A\u0438\u0440\u0433\u0438\u0437\u0441\u043A\u0438\u0445 \u0441\u043E\u043C\u043E\u0432\",\r\n            \"Value\": 91.5697,\r\n            \"Previous\": 91.2909\r\n        },\r\n        \"CNY\": {\r\n            \"ID\": \"R01375\",\r\n            \"NumCode\": \"156\",\r\n            \"CharCode\": \"CNY\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u041A\u0438\u0442\u0430\u0439\u0441\u043A\u0438\u0445 \u044E\u0430\u043D\u0435\u0439\",\r\n            \"Value\": 92.8355,\r\n            \"Previous\": 92.447\r\n        },\r\n        \"MDL\": {\r\n            \"ID\": \"R01500\",\r\n            \"NumCode\": \"498\",\r\n            \"CharCode\": \"MDL\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u041C\u043E\u043B\u0434\u0430\u0432\u0441\u043A\u0438\u0445 \u043B\u0435\u0435\u0432\",\r\n            \"Value\": 35.7314,\r\n            \"Previous\": 35.5218\r\n        },\r\n        \"NOK\": {\r\n            \"ID\": \"R01535\",\r\n            \"NumCode\": \"578\",\r\n            \"CharCode\": \"NOK\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u041D\u043E\u0440\u0432\u0435\u0436\u0441\u043A\u0438\u0445 \u043A\u0440\u043E\u043D\",\r\n            \"Value\": 74.2173,\r\n            \"Previous\": 74.3848\r\n        },\r\n        \"PLN\": {\r\n            \"ID\": \"R01565\",\r\n            \"NumCode\": \"985\",\r\n            \"CharCode\": \"PLN\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u041F\u043E\u043B\u044C\u0441\u043A\u0438\u0439 \u0437\u043B\u043E\u0442\u044B\u0439\",\r\n            \"Value\": 16.883,\r\n            \"Previous\": 16.877\r\n        },\r\n        \"RON\": {\r\n            \"ID\": \"R01585F\",\r\n            \"NumCode\": \"946\",\r\n            \"CharCode\": \"RON\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0420\u0443\u043C\u044B\u043D\u0441\u043A\u0438\u0439 \u043B\u0435\u0439\",\r\n            \"Value\": 15.1945,\r\n            \"Previous\": 15.1712\r\n        },\r\n        \"XDR\": {\r\n            \"ID\": \"R01589\",\r\n            \"NumCode\": \"960\",\r\n            \"CharCode\": \"XDR\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0421\u0414\u0420 (\u0441\u043F\u0435\u0446\u0438\u0430\u043B\u044C\u043D\u044B\u0435 \u043F\u0440\u0430\u0432\u0430 \u0437\u0430\u0438\u043C\u0441\u0442\u0432\u043E\u0432\u0430\u043D\u0438\u044F)\",\r\n            \"Value\": 88.3883,\r\n            \"Previous\": 88.1098\r\n        },\r\n        \"SGD\": {\r\n            \"ID\": \"R01625\",\r\n            \"NumCode\": \"702\",\r\n            \"CharCode\": \"SGD\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0421\u0438\u043D\u0433\u0430\u043F\u0443\u0440\u0441\u043A\u0438\u0439 \u0434\u043E\u043B\u043B\u0430\u0440\",\r\n            \"Value\": 46.9804,\r\n            \"Previous\": 46.8495\r\n        },\r\n        \"TJS\": {\r\n            \"ID\": \"R01670\",\r\n            \"NumCode\": \"972\",\r\n            \"CharCode\": \"TJS\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0422\u0430\u0434\u0436\u0438\u043A\u0441\u043A\u0438\u0445 \u0441\u043E\u043C\u043E\u043D\u0438\",\r\n            \"Value\": 67.7305,\r\n            \"Previous\": 67.4275\r\n        },\r\n        \"TRY\": {\r\n            \"ID\": \"R01700J\",\r\n            \"NumCode\": \"949\",\r\n            \"CharCode\": \"TRY\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0422\u0443\u0440\u0435\u0446\u043A\u0430\u044F \u043B\u0438\u0440\u0430\",\r\n            \"Value\": 11.1312,\r\n            \"Previous\": 11.3181\r\n        },\r\n        \"TMT\": {\r\n            \"ID\": \"R01710A\",\r\n            \"NumCode\": \"934\",\r\n            \"CharCode\": \"TMT\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u041D\u043E\u0432\u044B\u0439 \u0442\u0443\u0440\u043A\u043C\u0435\u043D\u0441\u043A\u0438\u0439 \u043C\u0430\u043D\u0430\u0442\",\r\n            \"Value\": 18.2746,\r\n            \"Previous\": 18.1929\r\n        },\r\n        \"UZS\": {\r\n            \"ID\": \"R01717\",\r\n            \"NumCode\": \"860\",\r\n            \"CharCode\": \"UZS\",\r\n            \"Nominal\": 10000,\r\n            \"Name\": \"\u0423\u0437\u0431\u0435\u043A\u0441\u043A\u0438\u0445 \u0441\u0443\u043C\u043E\u0432\",\r\n            \"Value\": 74.5078,\r\n            \"Previous\": 74.1744\r\n        },\r\n        \"UAH\": {\r\n            \"ID\": \"R01720\",\r\n            \"NumCode\": \"980\",\r\n            \"CharCode\": \"UAH\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0423\u043A\u0440\u0430\u0438\u043D\u0441\u043A\u0438\u0445 \u0433\u0440\u0438\u0432\u0435\u043D\",\r\n            \"Value\": 24.9514,\r\n            \"Previous\": 24.765\r\n        },\r\n        \"CZK\": {\r\n            \"ID\": \"R01760\",\r\n            \"NumCode\": \"203\",\r\n            \"CharCode\": \"CZK\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0427\u0435\u0448\u0441\u043A\u0438\u0445 \u043A\u0440\u043E\u043D\",\r\n            \"Value\": 28.1514,\r\n            \"Previous\": 28.1084\r\n        },\r\n        \"SEK\": {\r\n            \"ID\": \"R01770\",\r\n            \"NumCode\": \"752\",\r\n            \"CharCode\": \"SEK\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u0428\u0432\u0435\u0434\u0441\u043A\u0438\u0445 \u043A\u0440\u043E\u043D\",\r\n            \"Value\": 67.7485,\r\n            \"Previous\": 67.9804\r\n        },\r\n        \"CHF\": {\r\n            \"ID\": \"R01775\",\r\n            \"NumCode\": \"756\",\r\n            \"CharCode\": \"CHF\",\r\n            \"Nominal\": 1,\r\n            \"Name\": \"\u0428\u0432\u0435\u0439\u0446\u0430\u0440\u0441\u043A\u0438\u0439 \u0444\u0440\u0430\u043D\u043A\",\r\n            \"Value\": 64.476,\r\n            \"Previous\": 64.4216\r\n        },\r\n        \"ZAR\": {\r\n            \"ID\": \"R01810\",\r\n            \"NumCode\": \"710\",\r\n            \"CharCode\": \"ZAR\",\r\n            \"Nominal\": 10,\r\n            \"Name\": \"\u042E\u0436\u043D\u043E\u0430\u0444\u0440\u0438\u043A\u0430\u043D\u0441\u043A\u0438\u0445 \u0440\u044D\u043D\u0434\u043E\u0432\",\r\n            \"Value\": 45.0295,\r\n            \"Previous\": 45.1281\r\n        },\r\n        \"KRW\": {\r\n            \"ID\": \"R01815\",\r\n            \"NumCode\": \"410\",\r\n            \"CharCode\": \"KRW\",\r\n            \"Nominal\": 1000,\r\n            \"Name\": \"\u0412\u043E\u043D \u0420\u0435\u0441\u043F\u0443\u0431\u043B\u0438\u043A\u0438 \u041A\u043E\u0440\u0435\u044F\",\r\n            \"Value\": 54.1234,\r\n            \"Previous\": 54.2865\r\n        },\r\n        \"JPY\": {\r\n            \"ID\": \"R01820\",\r\n            \"NumCode\": \"392\",\r\n            \"CharCode\": \"JPY\",\r\n            \"Nominal\": 100,\r\n            \"Name\": \"\u042F\u043F\u043E\u043D\u0441\u043A\u0438\u0445 \u0438\u0435\u043D\",\r\n            \"Value\": 58.9505,\r\n            \"Previous\": 58.8714\r\n        }\r\n    }\r\n}";

            CbrResponse cbrResponse = await "https://www.cbr-xml-daily.ru/daily_json.js".GetJsonAsync<CbrResponse>();

            //CbrResponse cbrResponse = JsonConvert.DeserializeObject<CbrResponse>(json);

            Console.WriteLine(cbrResponse.Valute.USD.Value);
        }
    }
}