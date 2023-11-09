using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientBillingRequestDTO
    {
        public long? ClientId { get; set; }
        public long BillingId { get; set; }

        public string? PaymentType { get; set; }

        public bool? IsCreateMonthlyStatement { get; set; }

        public bool? IsCreateMonthlySuperBills { get; set; }

        public string? EmailNotification { get; set; }

        public List<CardDTO>? Card { get; set; }

        public List<InsuranceDTO>? Insurance { get; set; }

        public bool? IsNotifyNewInvoice { get; set; }

        public bool? IsNotifyNewStatement { get; set; }

        public bool? IsnotifyNewSuperBills { get; set; }
    }

    public class CardDTO
    {
        public long CardId { get; set; }

        public long? CardNumber { get; set; }

        public DateTime? DateExpire { get; set; }

        public string? CardType { get; set; }

        public bool? IsSetDefault { get; set; }
    }
    public class InsuranceDTO
    {
        public long InsuranceId { get; set; }

        public int? InsuranceType { get; set; }

        public int? PrimaryInsured { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public int? Sex { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public long? Year { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public long? ZipCode { get; set; }

        public long? MemberId { get; set; }

        public long? PlanId { get; set; }

        public long? GroupId { get; set; }

        public decimal? Copay { get; set; }

        public string? SendPayment { get; set; }

        public decimal? Deductible { get; set; }

        public string? InsurancePayerPhone { get; set; }

        public string? InsurancePayerFax { get; set; }

        public string? EmployerOrSchool { get; set; }

        public string? InsuranceCardPhoto { get; set; }
    }
}
