using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class CalenderSettingRepo : ICalenderSettingRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public CalenderSettingRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllCalenderSettingResponseDTO> GetAllCalenderSetting()
        {
            List<GetAllCalenderSettingResponseDTO> response = new List<GetAllCalenderSettingResponseDTO>();
            List<CalenderSetting> list = _context.CalenderSettings.ToList();
            response = _mapper.Map<List<GetAllCalenderSettingResponseDTO>>(list);
            return response;
        }

<<<<<<< HEAD
        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(long Id)
        {
            GetAllCalenderSettingResponseDTO response = new GetAllCalenderSettingResponseDTO();
            CalenderSetting item = _context.CalenderSettings.Where(x => x.CalenderId == Id).FirstOrDefault();
=======
        public GetAllCalenderSettingResponseDTO GetCalenderSettingById(int id)
        {
            GetAllCalenderSettingResponseDTO response = new GetAllCalenderSettingResponseDTO();
            CalenderSetting item = _context.CalenderSettings.Where(x => x.CalenderId == id).FirstOrDefault();
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
            response = _mapper.Map<GetAllCalenderSettingResponseDTO>(item);
            return response;
        }

        public bool SaveCalenderSetting(GetAllCalenderSettingRequestDTO request)
        {
            try
            {
                CalenderSetting CalenderSetting = new CalenderSetting();
                if (request.CalenderId == 0)
                {
                    CalenderSetting = _mapper.Map<CalenderSetting>(request);
                    _context.CalenderSettings.Add(CalenderSetting);
                    _context.SaveChanges();
                }
                else
                {
                    CalenderSetting = _context.CalenderSettings.Where(x => x.CalenderId == request.CalenderId).FirstOrDefault();
                    CalenderSetting = _mapper.Map(request, CalenderSetting);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

<<<<<<< HEAD
        public bool DeleteCalenderSetting(long Id)
        {
            try
            {
                CalenderSetting calenderSetting = _context.CalenderSettings.FirstOrDefault(x => x.CalenderId == Id);
                calenderSetting.IsActive = false;
=======
        public bool DeleteCalenderSetting(int id)
        {
            try
            {
                var CalenderSetting = _context.CalenderSettings.FirstOrDefault(x => x.CalenderId == id);
                _context.CalenderSettings.Remove(CalenderSetting);
                _context.SaveChanges();
>>>>>>> 913fac8c58a4f093a2d8eaf4f031e037ed49ff40
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
