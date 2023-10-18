using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class ServiceSettingRepo : IServiceSettingRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ServiceSettingRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllServiceSettingResponseDTO> GetAllServiceSetting()
        {
            List<GetAllServiceSettingResponseDTO> response = new List<GetAllServiceSettingResponseDTO>();
            List<ServiceSetting> list = _context.ServiceSettings.ToList();
            response = _mapper.Map<List<GetAllServiceSettingResponseDTO>>(list);
            return response;
        }

        public GetAllServiceSettingResponseDTO GetServiceSettingById(int id)
        {
            GetAllServiceSettingResponseDTO response = new GetAllServiceSettingResponseDTO();
            ServiceSetting item = _context.ServiceSettings.Where(x => x.ServiceId == id).FirstOrDefault();
            response = _mapper.Map<GetAllServiceSettingResponseDTO>(item);
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
                    _context.ServiceSettings.Add(ServiceSetting);
                    _context.SaveChanges();
                }
                else
                {
                    ServiceSetting = _context.ServiceSettings.Where(x => x.ServiceId == request.ServiceId).FirstOrDefault();
                    ServiceSetting = _mapper.Map(request, ServiceSetting);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteServiceSetting(int id)
        {
            try
            {
                var ServiceSetting = _context.ServiceSettings.FirstOrDefault(x => x.ServiceId == id);
                _context.ServiceSettings.Remove(ServiceSetting);
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
