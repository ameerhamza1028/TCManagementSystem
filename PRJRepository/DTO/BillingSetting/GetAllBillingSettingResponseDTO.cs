using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.BillingSetting
{
    public class GetAllBillingSettingResponseDTO
    {
        public int BillingId { get; set; }

        public decimal? BillingCurrency { get; set; }

        public long? TaxId { get; set; }

        public long? OrgNpi { get; set; }

        public bool? IsAppointmentService { get; set; }

        public bool? IsProfessionalService { get; set; }

        public bool? IsDaily { get; set; }

        public bool? IsMonthly { get; set; }

        public bool? IsManually { get; set; }

        public int? InvoicePastDue { get; set; }

        public int? MonthlyStatement { get; set; }

        public int? MonthlySuperbill { get; set; }

        public int? DocumentDelay { get; set; }

        public bool? IsNewClientStatement { get; set; }

        public bool? IsNewClientSuperBills { get; set; }

        public DateTime? CreationDate { get; set; }

        public long? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
