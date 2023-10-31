using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.DTO.Appointment;
using PRJRepository.DTO.AppointmentPayment;
using PRJRepository.DTO.AvailableSlot;
using PRJRepository.DTO.BillingSetting;
using PRJRepository.DTO.CalenderSetting;
using PRJRepository.DTO.Card;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.ClientAddress;
using PRJRepository.DTO.ClientForm;
using PRJRepository.DTO.Clinic;
using PRJRepository.DTO.ClinicLocation;
using PRJRepository.DTO.EditClient;
using PRJRepository.DTO.Email;
using PRJRepository.DTO.Insurance;
using PRJRepository.DTO.InsurranceSetting;
using PRJRepository.DTO.Invoice;
using PRJRepository.DTO.License;
using PRJRepository.DTO.Login;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.Organization;
using PRJRepository.DTO.Phone;
using PRJRepository.DTO.Service;
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
            CreateMap<TcUser, GetAllUserResponseDTO>().ReverseMap();
            CreateMap<TcUser, GetAllUserRequestDTO>().ReverseMap();
            CreateMap<License, GetAllLicenseResponseDTO>().ReverseMap();
            CreateMap<License, GetAllLicenseRequestDTO>().ReverseMap();
            CreateMap<AppointmentPayment, GetAllAppointmentPaymentResponseDTO>().ReverseMap();
            CreateMap<AppointmentPayment, GetAllAppointmentPaymentRequestDTO>().ReverseMap();
            CreateMap<Message, GetMessageResponseDTO>().ReverseMap();
            CreateMap<Message, GetMessageRequestDTO>().ReverseMap();
            CreateMap<EditClient, SaveEditClientResponseDTO>().ReverseMap();
            CreateMap<EditClient, SaveEditClientRequestDTO>().ReverseMap();
            CreateMap<Phone, GetAllPhoneResponseDTO>().ReverseMap();
            CreateMap<Phone, GetAllPhoneRequestDTO>().ReverseMap();
            CreateMap<Address, GetAllClientAddressResponseDTO>().ReverseMap();
            CreateMap<Address, GetAllClientAddressRequestDTO>().ReverseMap();
            CreateMap<Card, GetAllCardResponseDTO>().ReverseMap();
            CreateMap<Card, GetAllCardRequestDTO>().ReverseMap();
            CreateMap<Insurance, GetAllInsuranceResponseDTO>().ReverseMap();
            CreateMap<Insurance, GetAllInsuranceRequestDTO>().ReverseMap();
            CreateMap<Service, GetAllServiceResponseDTO>().ReverseMap();
            CreateMap<Service, GetAllServiceRequestDTO>().ReverseMap();
            CreateMap<Email, GetAllEmailResponseDTO>().ReverseMap();
            CreateMap<Email, GetAllEmailRequestDTO>().ReverseMap();
        }
    }
}
