using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.BillingSetting
{
    public class GetAllBillingSettingRequestDTO
    {
        public int BillingId { get; set; }

        public int? BillingCurrencyId { get; set; }

        public long? TaxId { get; set; }

        public long? OrgNpi { get; set; }

        public int? ServiceDefaultType { get; set; }

        public int? InvoiceCreation { get; set; }

        public int? InvoicePastDue { get; set; }

        public bool? IsGenerateInvoice { get; set; }

        public int? MonthlyStatement { get; set; }

        public int? MonthlySuperbill { get; set; }

        public int? DocumentDelay { get; set; }

        public bool? IsNewClientStatement { get; set; }

        public bool? IsNewClientSuperBills { get; set; }

        public int? DefaultNotification { get; set; }
    }
}
