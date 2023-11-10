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
            List<Models.Client> list = _context.Clients.ToList();
            foreach (var editClient in list)
            {
                SaveEditClientResponseDTO clientResponse = new SaveEditClientResponseDTO
                {
                    ClientId = editClient.ClientId,
                    FirstName = editClient.FirstName1,
                    LastName = editClient.LastName1,
                    ClinicianName = _context.TcUsers.Where(x => x.UserId == editClient.PrimaryClinicianId).Select(x => x.UserName).FirstOrDefault(),
                    IntakeDate = DateTime.UtcNow,
                    LastAppointment = null,
                    ClientEmail = editClient.Email1,
                    PhoneNumber = _context.Phones.Where(x => x.ClientId == editClient.ClientId).Select(x => x.PhoneNumber).FirstOrDefault(),
                    Status = true,
                    InsuranceId = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceId).FirstOrDefault(),
                    InsuranceType = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceType).FirstOrDefault(),
                    Address = _context.Addresses.Where(x => x.ClientId == editClient.ClientId).Select(x => x.Address1).FirstOrDefault(),
                    PaymentType = _context.EditClientBillings.Where(x => x.ClientId == editClient.ClientId).Select(x => x.PaymentPay).FirstOrDefault(),
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

                if (request.ClientType == 1)
                {
                    EditClient edit = new EditClient();
                    edit.ClientId = client.ClinicId;
                    edit.FirstName = request.FirstName1;
                    edit.LastName = request.LastName1;
                    edit.PrimaryClinicianId = request.PrimaryClinicianId;
                    edit.ClientEmail = request.Email1;
                    edit.LocationType = request.Location;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    Phone phone = new Phone();
                    phone.ClientId = client.ClinicId;
                    phone.PhoneNumber = request.Phone1;
                    phone.ContactId = 0;
                    _context.Phones.Add(phone);
                    _context.SaveChanges();
                    EditClientBilling editbilling = new EditClientBilling();
                    editbilling.ClientId = client.ClientId;
                    editbilling.PaymentPay = request.PaymentType;
                    _context.EditClientBillings.Add(editbilling);
                    _context.SaveChanges();
                }

                else if (request.ClientType == 2)
                {
                    EditClient edit = new EditClient();
                    edit.ClientId = client.ClientId;
                    edit.FirstName = request.FirstName1;
                    edit.LastName = request.LastName1;
                    edit.PrimaryClinicianId = request.PrimaryClinicianId;
                    edit.ClientEmail = request.Email1;
                    edit.LocationType = request.Location;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    Phone phone1 = new Phone();
                    phone1.ClientId = client.ClientId;
                    phone1.PhoneNumber = request.Phone1;
                    phone1.ContactId = 0;
                    _context.Phones.Add(phone1);
                    _context.SaveChanges();
                    EditClientContact editcontact = new EditClientContact();
                    editcontact.ClientId = client.ClientId;
                    editcontact.ContactFirstName = request.FirstName2;
                    editcontact.ContactLastName = request.LastName2;
                    editcontact.ContactRelationshipStatus = request.Relationship;
                    editcontact.ConatactEmail = request.Email2;
                    _context.EditClientContacts.Add(editcontact);
                    _context.SaveChanges();
                    Phone phone2 = new Phone();
                    phone2.ClientId = client.ClientId;
                    phone2.PhoneNumber = request.Phone2;
                    phone2.ContactId = client.ClientId;
                    _context.Phones.Add(phone2);
                    _context.SaveChanges();
                }

                else
                {
                    EditClient edit = new EditClient();
                    edit.ClientId = client.ClientId;
                    edit.FirstName = request.FirstName1;
                    edit.LastName = request.LastName1;
                    edit.PrimaryClinicianId = request.PrimaryClinicianId;
                    edit.ClientEmail = request.Email1;
                    edit.LocationType = request.Location;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    Phone phone1 = new Phone();
                    phone1.ClientId = client.ClientId;
                    phone1.PhoneNumber = request.Phone1;
                    phone1.ContactId = 0;
                    _context.Phones.Add(phone1);
                    _context.SaveChanges();
                    EditClient edit1 = new EditClient();
                    edit1.ClientId = client.ClientId;
                    edit1.FirstName = request.FirstName2;
                    edit1.LastName = request.LastName2;
                    edit1.PrimaryClinicianId = request.PrimaryClinicianId2;
                    edit1.ClientEmail = request.Email2;
                    edit1.LocationType = request.Location2;
                    _context.EditClients.Add(edit1);
                    _context.SaveChanges();
                    Phone phone2 = new Phone();
                    phone2.ClientId = client.ClientId;
                    phone2.ContactId = 0;
                    phone2.PhoneNumber = request.Phone2;
                    _context.Phones.Add(phone2);
                    _context.SaveChanges();
                    EditClientBilling editbilling = new EditClientBilling();
                    editbilling.ClientId = client.ClientId;
                    editbilling.PaymentPay = request.PaymentType;
                    _context.EditClientBillings.Add(editbilling);
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
