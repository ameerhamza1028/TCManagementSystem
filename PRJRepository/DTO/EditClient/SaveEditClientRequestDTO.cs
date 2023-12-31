﻿using PRJRepository.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.EditClient
{
    public class SaveEditClientRequestDTO
    {
        public long EditClientId { get; set; }

        public long? ClientId { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Suffix { get; set; }

        public string? NameToGoBy { get; set; }

        public int? PrimaryClinicianId { get; set; }

        public bool? IsAppointments { get; set; }

        public bool? IsCompletingDocuments { get; set; }

        public string? ClientEmail { get; set; }

        public bool? IsReminderDayOne { get; set; }

        public bool? IsReminderDayTwo { get; set; }

        public bool? IsReminderDayThree { get; set; }

        public bool? IsReminderDayFive { get; set; }

        public bool? IsReminderWeek { get; set; }

        public string? LocationType { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public long? Year { get; set; }

        public int? Sex { get; set; }

        public string? GenderIdentity { get; set; }

        public int? RelationshipStatus { get; set; }

        public int? EmploymentStatus { get; set; }

        public int? HumanRace { get; set; }

        public string? FirstName1 { get; set; }

        public string? MiddleName1 { get; set; }

        public string? LastName1 { get; set; }

        public string? Suffix1 { get; set; }

        public string? NameToGoBy1 { get; set; }

        public int? PrimaryClinicianId1 { get; set; }

        public bool? IsAppointments1 { get; set; }

        public bool? IsCompletingDocuments1 { get; set; }

        public string? ClientEmail1 { get; set; }

        public bool? IsReminderDayOne1 { get; set; }

        public bool? IsReminderDayTwo1 { get; set; }

        public bool? IsReminderDayThree1 { get; set; }

        public bool? IsReminderDayFive1 { get; set; }

        public bool? IsReminderWeek1 { get; set; }

        public string? LocationType1 { get; set; }

        public int? Month1 { get; set; }

        public int? Day1 { get; set; }

        public int? Year1 { get; set; }

        public int? Sex1 { get; set; }

        public string? GenderIdentity1 { get; set; }

        public int? RelationshipStatus1 { get; set; }

        public int? EmploymentStatus1 { get; set; }

        public int? HumanRace1 { get; set; }
        public List<Phone1DTO>? Phone { get; set; }
        public List<Address1DTO>? Address { get; set; }

        
    }
    public class Phone1DTO
    {

        public long PhoneId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhoneType { get; set; }

        public bool? IsSendTextMessage { get; set; }

        public bool? IsSendVoiceMessage { get; set; }

        public int? CouplePhoneId {  get; set; }
    }

    public class Address1DTO
    {
        public long AddressId { get; set; }

        public string? Address1 { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }


        public int? StateId { get; set; }

        public long? ZipCode { get; set; }
    }
}
