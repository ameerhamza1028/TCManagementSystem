using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJRepository.DTO.Message;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public UserRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<GetAllUserResponseDTO> GetAllUserByClinicId(long Id)
        {
            List<GetAllUserResponseDTO> response = new List<GetAllUserResponseDTO>();
            List<TcUser> list = _context.TcUsers.Where(x => x.ClinicId == Id).ToList();
            response = _mapper.Map<List<GetAllUserResponseDTO>>(list);
            return response;
        }

        public EditUserResponseDTO GetUserById(long Id)
        {
            EditUserResponseDTO response = new EditUserResponseDTO();
            Models.TcUser item = _context.TcUsers.Where(x => x.UserId == Id).FirstOrDefault();
            if (item != null)
            {
                response= _mapper.Map<EditUserResponseDTO>(item);
            }

            return response;
        }
        public bool SaveUser(GetAllUserRequestDTO request)
        {
                try
                {
                    Login login = _mapper.Map<Login>(request);
                    login.Email = request.Email;
                    login.Password = GenerateRandomPassword(15);
                    login.IsTermsAndConditions = true;
                    login.IsRememberMe = true;
                    login.IsActive = true;
                    login.CreationDate = DateTime.UtcNow;
                    login.RoleId = request.UserType;
                    _context.Logins.Add(login);
                    _context.SaveChanges();
                    TcUser user = new TcUser();
                    if (request.UserId == 0)
                    {
                        user = _mapper.Map<TcUser>(request);
                        if (request.AddressType == "SameAsClinic")
                        {
                            Clinic clinic = _context.Clinics.Where(x => x.ClinicId == request.ClinicId).FirstOrDefault();
                            user.CountryId = clinic.CountryId;
                            user.StateId = clinic.StateId;
                            user.CityId = clinic.CityId;
                            user.ZipCode = clinic.ZipCode;
                        }
                        user.IsActive = true;
                        user.CreationDate = DateTime.UtcNow;
                        user.LoginId = login.LoginId;
                        _context.TcUsers.Add(user);
                    }
                    else
                    {
                        user = _context.TcUsers.FirstOrDefault(x => x.UserId == request.UserId);

                        if (user != null)
                        {
                            _mapper.Map(request, user);
                        }
                    }

                    _context.SaveChanges();


                    return true;
                }
                catch (Exception ex)
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
        public bool DeleteUser(long Id,string Name)
        {
            try
            {
                TcUser user = _context.TcUsers.FirstOrDefault(x => x.UserId == Id && x.UserName == Name);
                if (user != null)
                {
                    user.IsActive = false;
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
