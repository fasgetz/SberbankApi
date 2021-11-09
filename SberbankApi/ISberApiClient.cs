using SberbankApi.Models.Reciept;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SberbankApi
{
    public interface ISberApiClient
    {
        /// <summary>
        /// Получение чека налоговой
        /// </summary>
        /// <param name="orderId">Номер заказа в системе Сбер</param>
        /// <returns></returns>
        Task<RecieptResponse> GetReciept(string orderId);
    }
}
