using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class AvailableSlotRepo : IAvailableSlotRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public AvailableSlotRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllSlotResponseDTO> GetAllAllAvailableSlot()
        {
            List<GetAllSlotResponseDTO> response = new List<GetAllSlotResponseDTO>();
            List<AvailableSlot> list = _context.AvailableSlots.ToList();
            response = _mapper.Map<List<GetAllSlotResponseDTO>>(list);
            return response;
        }

        public GetAllSlotResponseDTO GetAvailableSlotById(int id)
        {
            GetAllSlotResponseDTO response = new GetAllSlotResponseDTO();
            AvailableSlot item = _context.AvailableSlots.Where(x => x.AppointmntSlotId == id).FirstOrDefault();
            response = _mapper.Map<GetAllSlotResponseDTO>(item);
            return response;
        }

        public bool SaveAvailableSlot(GetAllSlotRequestDTO request)
        {
            try
            {
                AvailableSlot availableSlot = new AvailableSlot();
                if (request.AppointmntSlotId == 0)
                {
                    availableSlot = _mapper.Map<AvailableSlot>(request);
                    _context.AvailableSlots.Add(availableSlot);
                    _context.SaveChanges();
                }
                else
                {
                    availableSlot = _context.AvailableSlots.Where(x => x.AppointmntSlotId == request.AppointmntSlotId).FirstOrDefault();
                    availableSlot = _mapper.Map(request, availableSlot);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAvailableSlot(int id)
        {
            try
            {
                var availableSlot = _context.AvailableSlots.FirstOrDefault(x => x.AppointmntSlotId == id);
                _context.AvailableSlots.Remove(availableSlot);
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
