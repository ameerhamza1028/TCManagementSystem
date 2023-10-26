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
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            LoginResponseDTO response = new LoginResponseDTO();

            Login login = _context.Logins.Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
            if(login != null) {
                response = _mapper.Map<LoginResponseDTO>(login);
            }
            return response; 
            
            
        }
    }
}
