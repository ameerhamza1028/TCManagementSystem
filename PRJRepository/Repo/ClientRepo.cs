using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.Interface;
using PRJRepository.Models;
using System.Text;

namespace PRJRepository.Repo
{
    public class ClientRepo : IClientRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ClientRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllClientResponseDTO> GetAllClient()
        {
            List<GetAllClientResponseDTO> response = new List<GetAllClientResponseDTO>();
            List<Models.Client> list = _context.Clients.ToList();
            response = _mapper.Map<List<GetAllClientResponseDTO>>(list);
            return response;
        }

        public EditClientResponseDTO GetClientById(long Id)
        {
            EditClientResponseDTO response = new EditClientResponseDTO();
            Models.Client item = _context.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<EditClientResponseDTO>(item);
            return response;
        }

        public bool SaveClient(GetAllClientRequestDTO request)
        {
            try
            {
                Login login = _mapper.Map<Login>(request);
                login.Email = request.Email1;
                login.Password = GenerateRandomPassword(15);
                login.IsTermsAndConditions = true;
                login.IsRememberMe = true;
                login.IsActive = true;
                login.CreationDate = DateTime.UtcNow;
                login.RoleId = 5;
                _context.Logins.Add(login);
                _context.SaveChanges();
                Models.Client client = new Models.Client();
                if (request.ClientId == 0)
                {
                    client = _mapper.Map<Models.Client>(request);
                    client.IsActive = true;
                    client.CreatedDate = DateTime.UtcNow;
                    client.LoginId = login.LoginId;
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

        public string GenerateRandomPassword(int length)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%";
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, allowedChars.Length);
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }

        public bool DeleteClient(long Id)
        {
            try
            {
               Client client = _context.Clients.FirstOrDefault(x => x.ClientId == Id);
               client.IsActive = false;
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
