using System;
using System.Collections.Generic;
using System.Text;

namespace SberbankApi.Models.Reciept
{
    /// <summary>
    /// Чек налоговой
    /// </summary>
    public class Reciept
    {
        public int receiptStatus { get; set; }
        public string uuid { get; set; }
        public string shift_number { get; set; }
        public string fiscal_receipt_number { get; set; }
        public long receipt_date_time { get; set; }
        public string fn_number { get; set; }
        public string ecr_registration_number { get; set; }
        public string fiscal_document_number { get; set; }
        public string fiscal_document_attribute { get; set; }
        public int amount_total { get; set; }
        public string fnsSite { get; set; }
    }
}
