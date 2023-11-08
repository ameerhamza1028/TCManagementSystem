using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientBillingResponseDTO
    {
        public long BillingId { get; set; }

        public bool? IsSelfPay { get; set; }

        public bool? IsInsurance { get; set; }

        public bool? IsCreateMonthlyStatement { get; set; }

        public bool? IsCreateMonthlySuperBills { get; set; }

        public string? EmailNotification { get; set; }

        public bool? IsNotifyNewInvoice { get; set; }

        public bool? IsNotifyNewStatement { get; set; }

        public bool? IsnotifyNewSuperBills { get; set; }
    }
}
