using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public UserRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllResponseDTO> GetAllUser()
        {
            List<GetAllResponseDTO> response = new List<GetAllResponseDTO>();
            List<Tcuser> list = _context.Tcusers.ToList();
            response = _mapper.Map<List<GetAllResponseDTO>>(list);
            return response;
        }

        public GetAllResponseDTO GetUserById(int id)
        {
            GetAllResponseDTO response = new GetAllResponseDTO();
            Tcuser item = _context.Tcusers.Where(x => x.ClientId == id).FirstOrDefault();
            response = _mapper.Map<GetAllResponseDTO>(item);
            return response;
        }

        public bool SaveUser(GetAllRequestDTO request)
        {
            try
            {
                Tcuser tcuser = new Tcuser();
                if (request.ClientId == 0)
                {
                    tcuser = _mapper.Map<Tcuser>(request);
                    _context.Tcusers.Add(tcuser);
                    _context.SaveChanges();
                }
                else
                {
                    tcuser = _context.Tcusers.Where(x => x.ClientId == request.ClientId).FirstOrDefault();
                    tcuser = _mapper.Map(request, tcuser);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var tcuser = _context.Tcusers.FirstOrDefault(x => x.ClientId == id);
               // tcuser = _mapper.Map<Tcuser>(id);
                _context.Tcusers.Remove(tcuser);
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
