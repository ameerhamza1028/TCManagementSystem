using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace TCManagementSystem.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Client, GetAllResponseDTO>().ReverseMap();
            CreateMap<Client, GetAllRequestDTO>().ReverseMap();
            CreateMap<Organization, GetAllOrganizationResponseDTO>().ReverseMap();
            CreateMap<Organization, GetAllOrganizationRequestDTO>().ReverseMap();
            CreateMap<Clinic, GetAllClinicResponseDTO>().ReverseMap();
            CreateMap<Clinic, GetAllClinicRequestDTO>().ReverseMap();
            CreateMap<Appointment, GetAllAppointmentResponseDTO>().ReverseMap();
            CreateMap<Appointment, GetAllAppointmentRequestDTO>().ReverseMap();
            CreateMap<AvailableSlot, GetAllSlotResponseDTO>().ReverseMap();
            CreateMap<AvailableSlot, GetAllSlotRequestDTO>().ReverseMap();
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
        }
    }
}
