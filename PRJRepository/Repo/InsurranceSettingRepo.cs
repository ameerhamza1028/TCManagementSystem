using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class InsurranceSettingRepo : IInsurranceSettingRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public InsurranceSettingRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllInsurranceSettingResponseDTO> GetAllInsurranceSetting()
        {
            List<GetAllInsurranceSettingResponseDTO> response = new List<GetAllInsurranceSettingResponseDTO>();
            List<InsurranceSetting> list = _context.InsurranceSettings.ToList();
            response = _mapper.Map<List<GetAllInsurranceSettingResponseDTO>>(list);
            return response;
        }

        public GetAllInsurranceSettingResponseDTO GetInsurranceSettingById(long Id)
        {
            GetAllInsurranceSettingResponseDTO response = new GetAllInsurranceSettingResponseDTO();
            InsurranceSetting item = _context.InsurranceSettings.Where(x => x.InsurranceId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllInsurranceSettingResponseDTO>(item);
            return response;
        }

        public bool SaveInsurranceSetting(GetAllInsurranceSettingRequestDTO request)
        {
            try
            {
                InsurranceSetting InsurranceSetting = new InsurranceSetting();
                if (request.InsurranceId == 0)
                {
                    InsurranceSetting = _mapper.Map<InsurranceSetting>(request);
                    _context.InsurranceSettings.Add(InsurranceSetting);
                    _context.SaveChanges();
                }
                else
                {
                    InsurranceSetting = _context.InsurranceSettings.Where(x => x.InsurranceId == request.InsurranceId).FirstOrDefault();
                    InsurranceSetting = _mapper.Map(request, InsurranceSetting);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInsurranceSetting(long Id)
        {
            try
            {
                InsurranceSetting insurranceSetting = _context.InsurranceSettings.FirstOrDefault(x => x.InsurranceId == Id);
                insurranceSetting.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
