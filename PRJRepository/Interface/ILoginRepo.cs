using PRJRepository.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ILoginRepo
    {
        public LoginResponseDTO Login(LoginRequestDTO request);
        public bool SaveLogin(SaveLoginRequestDTO request);
    }
}
