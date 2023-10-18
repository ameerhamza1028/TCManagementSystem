using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class ClinicRepo : IClinicRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ClinicRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllClinicResponseDTO> GetAllClinic()
        {
            List<GetAllClinicResponseDTO> response = new List<GetAllClinicResponseDTO>();
            List<Clinic> list = _context.Clinics.ToList();
            response = _mapper.Map<List<GetAllClinicResponseDTO>>(list);
            return response;
        }

        public GetAllClinicResponseDTO GetClinicById(int id)
        {
            GetAllClinicResponseDTO response = new GetAllClinicResponseDTO();
            Clinic item = _context.Clinics.Where(x => x.ClinicId == id).FirstOrDefault();
            response = _mapper.Map<GetAllClinicResponseDTO>(item);
            return response;
        }

        public bool SaveClinic(GetAllClinicRequestDTO request)
        {
            try
            {
                Clinic clinic = new Clinic();
                if (request.ClinicId == 0)
                {
                    clinic = _mapper.Map<Clinic>(request);
                    _context.Clinics.Add(clinic);
                    _context.SaveChanges();
                }
                else
                {
                    clinic = _context.Clinics.Where(x => x.ClinicId == request.ClinicId).FirstOrDefault();
                    clinic = _mapper.Map(request, clinic);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClinic(int id)
        {
            try
            {
                var clinic = _context.Clinics.FirstOrDefault(x => x.ClinicId == id);
                _context.Clinics.Remove(clinic);
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
