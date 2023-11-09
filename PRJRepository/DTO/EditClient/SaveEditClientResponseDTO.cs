﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientResponseDTO
    {
        public long? ClientId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ClinicianName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ClientEmail { get; set; }

        public string? Address { get; set; }

        public string? PaymentType { get; set; }

        public long? InsuranceId { get; set; }

        public int? InsuranceType { get; set; }

        public DateTime? IntakeDate { get; set; }

        public string? LastAppointment {  get; set; }

        public bool? Status { get; set; }
    }
}
