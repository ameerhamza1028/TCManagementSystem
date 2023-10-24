using AutoMapper;
using PRJRepository.DTO.AvailableSlot;
using PRJRepository.Interface;
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

        public List<GetAllSlotAvailableResponseDTO> GetAllAllAvailableSlot()
        {
            List<GetAllSlotAvailableResponseDTO> response = new List<GetAllSlotAvailableResponseDTO>();
            List<AvailableSlot> list = _context.AvailableSlots.ToList();
            response = _mapper.Map<List<GetAllSlotAvailableResponseDTO>>(list);
            return response;
        }

        public GetAllSlotAvailableResponseDTO GetAvailableSlotById(long Id)
        {
            GetAllSlotAvailableResponseDTO response = new GetAllSlotAvailableResponseDTO();
            AvailableSlot item = _context.AvailableSlots.Where(x => x.AppointmntSlotId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllSlotAvailableResponseDTO>(item);
            return response;
        }

        public bool SaveAvailableSlot(GetAllAvailableSlotRequestDTO request)
        {
            try
            {
                AvailableSlot availableSlot = new AvailableSlot();
                if (request.AppointmntSlotId == 0)
                {
                    availableSlot = _mapper.Map<AvailableSlot>(request);
                    availableSlot.IsActive = true;
                    availableSlot.CreationDate = DateTime.UtcNow;
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

        public bool DeleteAvailableSlot(long Id)
        {
            try
            {
                AvailableSlot availableSlot = _context.AvailableSlots.FirstOrDefault(x => x.AppointmntSlotId == Id);
                availableSlot.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
