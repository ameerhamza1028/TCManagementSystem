using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using PRJRepository.Interface;
using PRJRepository.Models;
using System.Numerics;
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

        public List<GetAllClientNameResponseDTO> GetAllClientNames(long Id)
        {
            List<GetAllClientNameResponseDTO> response = new List<GetAllClientNameResponseDTO>();  
            List<Client> list = _context.Clients.Where(x => x.ClinicId == Id).ToList();
            foreach (var item in list)
            {
                GetAllClientNameResponseDTO name = new GetAllClientNameResponseDTO()
                {
                    ClientName1 = item.FirstName1 + " " + item.LastName1,
                    ClientName2 = item.FirstName2 + " " + item.LastName2,

                };
                response.Add(name); 
            }
            return response;
        }
        public List<SaveEditClientResponseDTO> GetAllClient()
        {
            List<SaveEditClientResponseDTO> response = new List<SaveEditClientResponseDTO>();
            List<Models.Client> list = _context.Clients.Where(x => x.IsActive == true).ToList();
            foreach (var editClient in list)
            {
                Address address = new Address();
                SaveEditClientResponseDTO clientResponse = new SaveEditClientResponseDTO
                {
                    ClientId = editClient.ClientId,
                    ClientType = editClient.ClientType,
                    FirstName = editClient.FirstName1,
                    LastName = editClient.LastName1,
                    ClinicianName = _context.Clinicians.Where(x => x.ClinicianId == editClient.PrimaryClinicianId).Select(x => x.ClinicianName).FirstOrDefault(),
                    IntakeDate = DateTime.UtcNow,
                    LastAppointment = null,
                    ClientEmail = editClient.Email1,
                    PhoneNumber = _context.Phones.Where(x => x.ClientId == editClient.ClientId).Select(x => x.PhoneNumber).FirstOrDefault(),
                    Status = true,
                    InsuranceId = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceId).FirstOrDefault(),
                    InsuranceType = _context.Insurances.Where(x => x.ClientId == editClient.ClientId).Select(x => x.InsuranceType).FirstOrDefault(),
                    CountryName = _context.Addresses .Where(address => address.ClientId == editClient.ClientId).Join( _context.Countries,address => address.CountryId, country => country.Id, (address, country) => country.Name).FirstOrDefault(),
                    StateName = _context.Addresses.Where(address => address.ClientId == editClient.ClientId).Join(_context.States,address => address.StateId, state => state.Id , (address,state) => state.Name).FirstOrDefault(),
                    CityName = _context.Addresses.Where(address => address.ClientId == editClient.ClientId).Join(_context.Cities,address => address.CityId, city => city.Id, (address,city) => city.Name).FirstOrDefault(),
                    ZipCode = _context.Addresses.Where(x => x.ClientId == editClient.ClientId).Select(x => x.ZipCode).FirstOrDefault(),
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
                    edit.ClientId = client.ClientId;
                    edit.FirstName = request.FirstName1;
                    edit.LastName = request.LastName1;
                    edit.PrimaryClinicianId = request.PrimaryClinicianId;
                    edit.ClientEmail = request.Email1;
                    edit.LocationType = request.Location;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    Phone phone = new Phone();
                    phone.ClientId = client.ClientId;
                    phone.PhoneNumber = request.Phone1;
                    phone.ContactId = 0;
                    phone.IsActive = true;
                    phone.PhoneType = request.PhoneType1;
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
                    phone1.IsActive = true;
                    phone1.PhoneType = request.PhoneType1;
                    _context.Phones.Add(phone1);
                    _context.SaveChanges();
                    EditClientContact editcontact = new EditClientContact();
                    editcontact.ClientId = client.ClientId;
                    editcontact.ContactFirstName = request.FirstName2;
                    editcontact.ContactLastName = request.LastName2;
                    editcontact.ContactRelationshipStatus = request.Relationship;
                    editcontact.ContactEmail = request.Email2;
                    editcontact.ContactEmailType = request.EmailType2;
                    _context.EditClientContacts.Add(editcontact);
                    _context.SaveChanges();
                    Phone phone2 = new Phone();
                    phone2.ClientId = client.ClientId;
                    phone2.PhoneNumber = request.Phone2;
                    phone2.ContactId = editcontact.ContactId;
                    phone2.IsActive = true;
                    phone2.PhoneType = request.PhoneType2;
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
                    edit.FirstName1 = request.FirstName2;
                    edit.LastName1 = request.LastName2;
                    edit.PrimaryClinicianId1 = request.PrimaryClinicianId2;
                    edit.ClientEmail1 = request.Email2;
                    edit.LocationType1 = request.Location2;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    Phone phone1 = new Phone();
                    phone1.ClientId = client.ClientId;
                    phone1.PhoneNumber = request.Phone1;
                    phone1.ContactId = 0;
                    phone1.PhoneType = request.PhoneType1;
                    phone1.IsActive = true;
                    _context.Phones.Add(phone1);
                    _context.SaveChanges();
                    Phone phone2 = new Phone();
                    phone2.ClientId = client.ClientId;
                    phone2.ContactId = 0;
                    phone2.PhoneNumber = request.Phone2;
                    phone2.PhoneType = request.PhoneType2;
                    phone2.IsActive = true;
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
                if (client != null)
                {
                    client.IsActive = false;
                    _context.SaveChanges();

                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }

        }
    }
}
