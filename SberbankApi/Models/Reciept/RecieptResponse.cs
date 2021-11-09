using System;
using System.Collections.Generic;
using System.Text;

namespace SberbankApi.Models.Reciept
{
    /// <summary>
    /// Ответ чека налоговой
    /// </summary>
    public class RecieptResponse
    {
        public string errorCode { get; set; }
        public string orderNumber { get; set; }
        public string orderId { get; set; }
        public List<Reciept> receipt { get; set; }
    }
}
