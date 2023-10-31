using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.Insurance
{
    public class GetAllInsuranceResponseDTO
    {
        public long InsuranceId { get; set; }

        public int? InsuranceType { get; set; }

        public int? PrimaryInsured { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Sex { get; set; }

        public string? Month { get; set; }

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

        public long? CreatedBy { get; set; }

    }
}
