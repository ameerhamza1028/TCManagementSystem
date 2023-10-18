using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace TCManagementSystem.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Tcuser, GetAllResponseDTO>().ReverseMap();
            CreateMap<Tcuser, GetAllRequestDTO>().ReverseMap();
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
            CreateMap<Form1, GetAllForm1RequestDTO>().ReverseMap();
            CreateMap<Form2, GetAllForm2RequestDTO>().ReverseMap();
            CreateMap<Form3, GetAllForm3RequestDTO>().ReverseMap();
            CreateMap<Form4, GetAllForm4RequestDTO>().ReverseMap();
            CreateMap<Form5, GetAllForm5RequestDTO>().ReverseMap();
            CreateMap<Form6, GetAllForm6RequestDTO>().ReverseMap();
            CreateMap<Form7, GetAllForm7RequestDTO>().ReverseMap();
            CreateMap<Form8, GetAllForm8RequestDTO>().ReverseMap();
            CreateMap<Form9, GetAllForm9RequestDTO>().ReverseMap();
            CreateMap<Form10, GetAllForm10RequestDTO>().ReverseMap();
            CreateMap<Form11, GetAllForm11RequestDTO>().ReverseMap();
            CreateMap<Form12, GetAllForm12RequestDTO>().ReverseMap();
            CreateMap<Form13, GetAllForm13RequestDTO>().ReverseMap();
            CreateMap<Form14, GetAllForm14RequestDTO>().ReverseMap();
            CreateMap<Form15, GetAllForm15RequestDTO>().ReverseMap();
            CreateMap<Form16, GetAllForm16RequestDTO>().ReverseMap();
            CreateMap<Form17, GetAllForm17RequestDTO>().ReverseMap();
            CreateMap<Form18, GetAllForm18RequestDTO>().ReverseMap();
            CreateMap<Form19, GetAllForm19RequestDTO>().ReverseMap();
            CreateMap<Form20, GetAllForm20RequestDTO>().ReverseMap();
        }
    }
}
