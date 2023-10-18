using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class ClientRepo : IClientRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ClientRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllResponseDTO> GetAllClient()
        {
            List<GetAllResponseDTO> response = new List<GetAllResponseDTO>();
            List<Models.Client> list = _context.Clients.ToList();
            response = _mapper.Map<List<GetAllResponseDTO>>(list);
            return response;
        }

        public GetAllResponseDTO GetClientById(long Id)
        {
            GetAllResponseDTO response = new GetAllResponseDTO();
            Models.Client item = _context.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllResponseDTO>(item);
            return response;
        }

        public bool SaveClient(GetAllRequestDTO request)
        {
            try
            {
                Models.Client client = new Models.Client();
                if (request.ClientId == 0)
                {
                    client = _mapper.Map<Models.Client>(request);
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                }
                else
                {
                    client = _context.Clients.Where(x => x.ClientId == request.ClientId).FirstOrDefault();
                    client = _mapper.Map(request, client);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClient(long Id)
        {
            try
            {
               Client client = _context.Clients.FirstOrDefault(x => x.ClientId == Id);
               client.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
