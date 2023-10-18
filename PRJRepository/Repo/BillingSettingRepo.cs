using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class BillingSettingRepo : IBillingSettingRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public BillingSettingRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllBillingSettingResponseDTO> GetAllBillingSetting()
        {
            List<GetAllBillingSettingResponseDTO> response = new List<GetAllBillingSettingResponseDTO>();
            List<BillingSetting> list = _context.BillingSettings.ToList();
            response = _mapper.Map<List<GetAllBillingSettingResponseDTO>>(list);
            return response;
        }

        public GetAllBillingSettingResponseDTO GetBillingSettingById(int id)
        {
            GetAllBillingSettingResponseDTO response = new GetAllBillingSettingResponseDTO();
            BillingSetting item = _context.BillingSettings.Where(x => x.BillingId == id).FirstOrDefault();
            response = _mapper.Map<GetAllBillingSettingResponseDTO>(item);
            return response;
        }

        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request)
        {
            try
            {
                BillingSetting BillingSetting = new BillingSetting();
                if (request.BillingId == 0)
                {
                    BillingSetting = _mapper.Map<BillingSetting>(request);
                    _context.BillingSettings.Add(BillingSetting);
                    _context.SaveChanges();
                }
                else
                {
                    BillingSetting = _context.BillingSettings.Where(x => x.BillingId == request.BillingId).FirstOrDefault();
                    BillingSetting = _mapper.Map(request, BillingSetting);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBillingSetting(int id)
        {
            try
            {
                var BillingSetting = _context.BillingSettings.FirstOrDefault(x => x.BillingId == id);
                _context.BillingSettings.Remove(BillingSetting);
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
