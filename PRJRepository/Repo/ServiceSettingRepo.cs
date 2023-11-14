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

        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting()
        {
            List<GetAllServiceSettingResponseDTO> response = new List<GetAllServiceSettingResponseDTO>();
            List<ServiceSetting> list = _context.ServiceSettings.ToList();
            foreach (var item in list)
            {
                GetAllServiceSettingResponseDTO Settingresponse = new GetAllServiceSettingResponseDTO()
                {
                    ServiceId = item.ServiceId,
                    Cptcode = item.Cptcode,
                    ServiceDescription = item.ServiceDescription,
                    Duration = item.Duration,
                    RatePerUnit = item.RatePerUnit,
                    ClinicianCount = _context.ClinicianServices.Where(x => x.ServiceId == item.ServiceId).Count(),

                };
                response.Add(Settingresponse);
            }
            return response;
        }


        public GetAllServiceSettingRequestDTO GetServiceSettingById(long Id)
        {
            GetAllServiceSettingRequestDTO response = new GetAllServiceSettingRequestDTO();
            ServiceSetting item = _context.ServiceSettings.Where(x => x.ServiceId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllServiceSettingRequestDTO>(item);
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
                serviceSetting.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
