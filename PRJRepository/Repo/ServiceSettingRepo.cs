using AutoMapper;
using PRJRepository.DTO.ServiceSetting;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Models;
using System.ComponentModel;

namespace PRJRepository.Repo
{
    public class ServiceSettingRepo : IServiceSettingRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ServiceSettingRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<GetAllServiceResponseDTO> GetAllServiceNames()
        {
            List<GetAllServiceResponseDTO> response = new List<GetAllServiceResponseDTO>();
            List<ServiceSetting> list = _context.ServiceSettings.ToList();
            foreach (var item in list)
            {
                GetAllServiceResponseDTO Settingresponse = new GetAllServiceResponseDTO()
                {
                    Cptcode = item.Cptcode,
                    ServiceDescription = item.ServiceDescription,
                    Duration = item.Duration,

                };
                response.Add(Settingresponse);
            }
            return response;
        }

        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting(long Id)
        {
            List<GetAllServiceSettingResponseDTO> response = new List<GetAllServiceSettingResponseDTO>();
            List<ServiceSetting> list = _context.ServiceSettings.Where(x => x.ClinicId == Id && x.IsActive == true).ToList();
            foreach (var item in list)
            {
                GetAllServiceSettingResponseDTO Settingresponse = new GetAllServiceSettingResponseDTO()
                {
                    ServiceName = item.ServiceName,
                    ServiceId = item.ServiceId,
                    Cptcode = item.Cptcode,
                    ServiceDescription = item.ServiceDescription,
                    Duration = item.Duration,
                    RatePerUnit = item.RatePerUnit,
                    ClinicianCount = _context.ClinicianServices.Where(x => x.ServiceId == item.ServiceId && x.IsActive == true).Count(),

                };
                response.Add(Settingresponse);
            }
            return response;
        }


        public EditServiceSettingResponseDTO GetServiceSettingById(long Id)
        {
            EditServiceSettingResponseDTO response = new EditServiceSettingResponseDTO();
            ServiceSetting item = _context.ServiceSettings.Where(x => x.ServiceId == Id).FirstOrDefault();
            response = _mapper.Map<EditServiceSettingResponseDTO>(item);
            return response;
        }

        public bool SaveServiceSetting(GetAllServiceSettingRequestDTO request)
        {
            try
            {
                ServiceSetting ServiceSetting = new ServiceSetting();
                if (request.ServiceId == 0)
                {
                    ServiceSetting = _mapper.Map<ServiceSetting>(request);
                    ServiceSetting.IsActive = true;
                    ServiceSetting.CreationDate = DateTime.UtcNow;
                    _context.ServiceSettings.Add(ServiceSetting);
                    _context.SaveChanges();

                    List<ClinicianDTO> clinicianList = request.Clinician;
                    foreach (var list in clinicianList)
                    {
                        ClinicianService clinicianservice = new ClinicianService();
                        clinicianservice.ClinicianId = list.ClinicianId;
                        clinicianservice.ClinicianName = _context.Clinicians.Where(x => x.ClinicianId == list.ClinicianId).Select(x => x.ClinicianName).FirstOrDefault();
                        clinicianservice.ServiceId = ServiceSetting.ServiceId;
                        clinicianservice.IsActive = true;
                        _context.ClinicianServices.Add(clinicianservice);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    ServiceSetting = _context.ServiceSettings.Where(x => x.ServiceId == request.ServiceId).FirstOrDefault();
                    ServiceSetting = _mapper.Map(request, ServiceSetting);
                    _context.SaveChanges();
                    List<ClinicianService> list1 = _context.ClinicianServices.Where(x => x.ServiceId == ServiceSetting.ServiceId).ToList();
                    foreach (var item in list1)
                    {
                        item.IsActive = false;
                        _context.SaveChanges();
                    }
                    List<ClinicianDTO> clinicianList = request.Clinician;
                    foreach (var list in clinicianList)
                    {
                        ClinicianService clinicianservice = new ClinicianService();
                        clinicianservice.ClinicianId = list.ClinicianId;
                        clinicianservice.ClinicianName = _context.Clinicians.Where(x => x.ClinicianId == list.ClinicianId).Select(x => x.ClinicianName).FirstOrDefault();
                        clinicianservice.ServiceId = ServiceSetting.ServiceId;
                        clinicianservice.IsActive = true;
                        _context.ClinicianServices.Add(clinicianservice);
                        _context.SaveChanges();
                    }
                }
                return true;
            }
            catch(Exception ex)
            { 
                return false;
            }
        }


        public bool DeleteServiceSetting(long Id)
        {
            try
            {
                ServiceSetting serviceSetting = _context.ServiceSettings.FirstOrDefault(x => x.ServiceId == Id);
                if(serviceSetting != null)
                {
                    serviceSetting.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else
                { return false; }
                
            }
            catch
            {
                return false;
            }

        }

        public List<GetAllClinicianServiceResponseDTO> GetClinicianServices(long Id)
        {
            List<GetAllClinicianServiceResponseDTO> response = new List<GetAllClinicianServiceResponseDTO>();
            List<ClinicianService> list = _context.ClinicianServices.Where(x => x.ServiceId == Id && x.IsActive == true).ToList();
            foreach (var item in list)
            {
                GetAllClinicianServiceResponseDTO clinicianresponse = new GetAllClinicianServiceResponseDTO()
                {

                    ClinicianId = item.ClinicianId,

                };
                response.Add(clinicianresponse);
            }
            return response;
        }
    }
}
