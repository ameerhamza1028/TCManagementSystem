using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.EntityModel;

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
        }
    }
}
