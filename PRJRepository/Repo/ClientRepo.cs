using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
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

        public List<SaveEditClientResponseDTO> GetAllClient()
        {
            List<SaveEditClientResponseDTO> response = new List<SaveEditClientResponseDTO>();
            List<Models.EditClient> list = _context.EditClients.ToList();
            foreach (var editClient in list)
            {
                SaveEditClientResponseDTO clientResponse = new SaveEditClientResponseDTO
                {
                    FirstName = editClient.FirstName,
                    MiddleName = editClient.MiddleName,
                    LastName = editClient.LastName,
                    ClinicianName = _context.TcUsers.Where(x => x.UserId == editClient.PrimaryClinicianId).Select(x => x.UserName).FirstOrDefault(),
                    IntakeDate = DateTime.UtcNow,
                    LastAppointment = null,
                    ClientEmail = editClient.ClientEmail,
                    PhoneNumber = _context.Phones.Where(x => x.ClientId == editClient.ClientId).Select(x => x.PhoneNumber).FirstOrDefault(),
                    Status = true,
                    InsuranceId = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceId).FirstOrDefault(),
                    InsuranceType = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceType).FirstOrDefault(),
                    AddressId = _context.Addresses.Where(x => x.ClientId == editClient.ClientId).Select(x => x.AddressId).FirstOrDefault(),
                    IsInsurrance = _context.EditClientBillings.Where(x => x.ClientId == editClient.ClientId).Select(x => x.IsInsurance).FirstOrDefault(),
                    IsSelfPay = _context.EditClientBillings.Where(x => x.ClientId == editClient.ClientId).Select(x => x.IsSelfPay).FirstOrDefault(),
                };
                response.Add(clientResponse);
            }

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
                
                EditClient edit = new EditClient();
                edit = _mapper.Map<EditClient>(request);
                _context.EditClients.Add(edit);
                _context.SaveChanges();

                EditClientContact editcontact = new EditClientContact();
                editcontact = _mapper.Map<EditClientContact>(request);
                _context.EditClientContacts.Add(editcontact);
                _context.SaveChanges();

                EditClientBilling editbilling = new EditClientBilling();
                editbilling = _mapper.Map<EditClientBilling>(request);
                _context.EditClientBillings.Add(editbilling);
                _context.SaveChanges();

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
