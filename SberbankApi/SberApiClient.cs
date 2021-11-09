using RestSharp;
using SberbankApi.Models.Reciept;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SberbankApi
{
    /// <summary>
    /// Клиент апи сбербанка
    /// </summary>
    public class SberApiClient : ISberApiClient
    {
        #region Поля

        /// <summary>
        /// Адрес api (в зависимости от типа тест/продакшен)
        /// </summary>
        private string urlApi
        {
            get
            {
                switch (sandbox)
                {
                    case (true):
                        return "https://3dsec.sberbank.ru/payment/rest/";
                    case (false):
                        return "https://securepayments.sberbank.ru/payment/rest/";
                }
            }
        }
        /// <summary>
        /// Имя учетной записи
        /// </summary>
        private readonly string username;
        /// <summary>
        /// Пароль учетной записи
        /// </summary>
        private readonly string password;
        /// <summary>
        /// Режим песочницы (по умолчанию true)
        /// </summary>
        private readonly bool sandbox;

        /// <summary>
        /// Клиент REST
        /// </summary>
        private readonly RestClient client;
        /// <summary>
        /// Запрос REST
        /// </summary>
        private readonly RestRequest request;

        #endregion

        /// <summary>
        /// Инициализация полей
        /// </summary>
        /// <param name="username">Имя учетной записи</param>
        /// <param name="password">Пароль учетной записи</param>
        /// <param name="sandbox">Режим песочницы (по умолчанию true)</param>
        public SberApiClient(string username, string password, bool sandbox = true)
        {
            this.username = username;
            this.password = password;
            this.sandbox = sandbox;

            client = new RestClient(urlApi);

            request = new RestRequest("", Method.GET);
            request.AddParameter("userName", username);
            request.AddParameter("password", password);
        }

        /// <summary>
        /// Получение чека налоговой
        /// </summary>
        /// <param name="orderId">Номер заказа в системе Сбер</param>
        /// <returns></returns>
        public async Task<RecieptResponse> GetReciept(string orderId)
        {
            request.Method = Method.GET;
            request.Resource = "getReceiptStatus.do";
            request.AddParameter("orderId", orderId);


            RecieptResponse response = await client.GetAsync<RecieptResponse>(request);

            return response;
        }
    }
}
