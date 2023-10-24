using AutoMapper;
using PRJRepository.DTO.Clinic;
using PRJRepository.Interface;
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

        public GetAllClinicResponseDTO GetClinicById(long Id)
        {
            GetAllClinicResponseDTO response = new GetAllClinicResponseDTO();
            Clinic item = _context.Clinics.Where(x => x.ClinicId == Id).FirstOrDefault();
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
                    clinic.IsActive = true;
                    clinic.CreationDate = DateTime.UtcNow;
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

        public bool DeleteClinic(long Id)
        {
            try
            {
                Clinic clinic = _context.Clinics.FirstOrDefault(x => x.ClinicId == Id);
                clinic.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
