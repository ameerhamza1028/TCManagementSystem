using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.DTO.Appointment;
using PRJRepository.DTO.AppointmentPayment;
using PRJRepository.DTO.AvailableSlot;
using PRJRepository.DTO.BillingSetting;
using PRJRepository.DTO.CalenderSetting;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.ClientForm;
using PRJRepository.DTO.Clinic;
using PRJRepository.DTO.ClinicLocation;
using PRJRepository.DTO.InsurranceSetting;
using PRJRepository.DTO.Invoice;
using PRJRepository.DTO.License;
using PRJRepository.DTO.Login;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.Organization;
using PRJRepository.DTO.ServiceSetting;
using PRJRepository.DTO.User;
using PRJRepository.Models;

namespace TCManagementSystem.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Login, LoginResponseDTO>().ReverseMap();
            CreateMap<Login, LoginRequestDTO>().ReverseMap();
            CreateMap<Client, GetAllClientResponseDTO>().ReverseMap();
            CreateMap<Client, GetAllClientRequestDTO>().ReverseMap();
            CreateMap<Organization, GetAllOrganizationResponseDTO>().ReverseMap();
            CreateMap<Organization, GetAllOrganizationRequestDTO>().ReverseMap();
            CreateMap<Clinic, GetAllClinicResponseDTO>().ReverseMap();
            CreateMap<Clinic, GetAllClinicRequestDTO>().ReverseMap();
            CreateMap<Appointment, GetAllAppointmentResponseDTO>().ReverseMap();
            CreateMap<Appointment, GetAllAppointmentRequestDTO>().ReverseMap();
            CreateMap<AvailableSlot, GetAllSlotAvailableResponseDTO>().ReverseMap();
            CreateMap<AvailableSlot, GetAllAvailableSlotRequestDTO>().ReverseMap();
            CreateMap<Invoice, GetAllInvoiceResponseDTO>().ReverseMap();
            CreateMap<Invoice, GetAllInvoiceRequestDTO>().ReverseMap();
            CreateMap<ClinicLocation, GetAllClinicLocationResponseDTO>().ReverseMap();
            CreateMap<ClinicLocation, GetAllClinicLocationRequestDTO>().ReverseMap();
            CreateMap<BillingSetting, GetAllBillingSettingResponseDTO>().ReverseMap();
            CreateMap<BillingSetting, GetAllBillingSettingRequestDTO>().ReverseMap();
            CreateMap<ServiceSetting, GetAllServiceSettingResponseDTO>().ReverseMap();
            CreateMap<ServiceSetting, GetAllServiceSettingRequestDTO>().ReverseMap();
            CreateMap<InsurranceSetting, GetAllInsurranceSettingResponseDTO>().ReverseMap();
            CreateMap<InsurranceSetting, GetAllInsurranceSettingRequestDTO>().ReverseMap();
            CreateMap<CalenderSetting, GetAllCalenderSettingResponseDTO>().ReverseMap();
            CreateMap<CalenderSetting, GetAllCalenderSettingRequestDTO>().ReverseMap();
            CreateMap<ClientForm, GetAllClientFormResponseDTO>().ReverseMap();
            CreateMap<ClientForm, GetAllClientFormRequestDTO>().ReverseMap();
            CreateMap<User, GetAllUserResponseDTO>().ReverseMap();
            CreateMap<User, GetAllUserRequestDTO>().ReverseMap();
            CreateMap<License, GetAllLicenseResponseDTO>().ReverseMap();
            CreateMap<License, GetAllLicenseRequestDTO>().ReverseMap();
            CreateMap<AppointmentPayment, GetAllAppointmentPaymentResponseDTO>().ReverseMap();
            CreateMap<AppointmentPayment, GetAllAppointmentPaymentRequestDTO>().ReverseMap();
            CreateMap<Message, GetMessageResponseDTO>().ReverseMap();
            CreateMap<Message, GetMessageRequestDTO>().ReverseMap();
        }
    }
}
