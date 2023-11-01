using AutoMapper;
using PRJRepository.DTO.Login;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class LoginRepo : ILoginRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public LoginRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveLogin(SaveLoginRequestDTO request)
        {
            try
            {
                Models.Login Login = new Models.Login();
                if (request.LoginId == 0)
                {
                    Login = _mapper.Map<Models.Login>(request);
                    Login.Password = GenerateRandomPassword(15);
                    Login.IsTermsAndConditions = true;
                    Login.IsRememberMe = true;
                    Login.IsActive = true;
                    Login.CreationDate = DateTime.UtcNow;
                    _context.Logins.Add(Login);
                    _context.SaveChanges();

                    string email = Login.Email;
                    string message = Login.Password;

                    SendEmail sendEmail = new SendEmail();
                    sendEmail.EmailSender(email, message);
                }
                else
                {
                    Login = _context.Logins.Where(x => x.LoginId == request.LoginId).FirstOrDefault();
                    Login = _mapper.Map(request, Login);
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
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            LoginResponseDTO response = new LoginResponseDTO();

            Login login = _context.Logins.Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
            if(login != null)
            {
                //response = _mapper.Map<LoginResponseDTO>(login);
                TcUser user = _context.TcUsers.Where(x => x.LoginId == login.LoginId).FirstOrDefault();
                if (user != null)
                {
                    response.UserId = user.UserId;
                    response.UserName = user.UserName;
                    response.StateName = user.StateName;
                    response.CityName = user.CityName;
                    response.Address = user.Address;
                    response.Phone = user.Phone;
                    response.Status = user.Status;
                    response.LoginId = user.LoginId;
                    response.Email = user.Email;
                    response.RoleName = _context.UserRoles.Where(x => x.RoleId == login.RoleId).Select(x => x.Title).FirstOrDefault();
                }
                
                Client client = _context.Clients.Where(x => x.LoginId == login.LoginId).FirstOrDefault();
                if (client != null) {
                    response.ClientId = client.ClientId;
                    response.FirstName1 = client.FirstName1;    
                    response.LastName1 = client.LastName1;
                    response.Email1 = client.Email1;
                    response.Phone1 = client.Phone1;
                    response.FirstName2 = client.FirstName2;
                    response.LastName2 = client.LastName2;
                    response.Email2 = client.Email2;
                    response.Phone2 = client.Phone2;
                    response.RoleName = _context.UserRoles.Where(x => x.RoleId == login.RoleId).Select(x => x.Title).FirstOrDefault();
                }
            }
            return response; 
            
            
        }
    }
}
