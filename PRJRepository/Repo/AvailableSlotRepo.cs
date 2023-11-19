using AutoMapper;
using PRJRepository.DTO.AvailableSlot;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class AvailableSlotRepo : IAvailableSlotRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public AvailableSlotRepo(TcemrProdContext context, IMapper mapper)
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
                if (request.AppointmntSlotId == 0)
                {
                    AvailableSlot AvailableSlot = _mapper.Map<AvailableSlot>(request);

                    if (TimeSpan.TryParse(request.StartTime, out TimeSpan parsedTime1) && TimeSpan.TryParse(request.EndTime, out TimeSpan parsedTime2))
                    {
                        AvailableSlot.StartTime = parsedTime1;
                        AvailableSlot.EndTime = parsedTime2;
                        TimeSpan totalDuration = parsedTime2 - parsedTime1;
                        TimeSpan slotDuration = TimeSpan.FromMinutes((double)request.Duration);
                        int numberOfSlots = (int)(totalDuration.TotalMinutes / slotDuration.TotalMinutes);
                        for (int i = 0; i < numberOfSlots; i++)
                        {
                            AvailableSlot slot = new AvailableSlot
                            {
                                StartTime = parsedTime1.Add(TimeSpan.FromMinutes(i * slotDuration.TotalMinutes)),
                                EndTime = parsedTime1.Add(TimeSpan.FromMinutes((i + 1) * slotDuration.TotalMinutes)),
                                TotalTime = slotDuration,
                                IsActive = true,
                                CreationDate = DateTime.UtcNow
                            };

                            _context.AvailableSlots.Add(slot);
                        }

                        _context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    AvailableSlot AvailableSlot = _context.AvailableSlots.FirstOrDefault(x => x.AppointmntSlotId == request.AppointmntSlotId);
                    if (AvailableSlot != null)
                    {
                        _mapper.Map(request, AvailableSlot);
                        if (TimeSpan.TryParse(request.StartTime, out TimeSpan parsedTime))
                        {
                            AvailableSlot.StartTime = parsedTime;
                            _context.SaveChanges();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
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
