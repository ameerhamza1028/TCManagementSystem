using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRJRepository.DTO.Login;
using PRJRepository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCManagementSystem.Helper;

namespace TCManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountLoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ILoginRepo _ILoginRepo;

        public AccountLoginController(
            IConfiguration config,
            IMapper IMapper,
            ILoginRepo ILoginRepo)
        {
            _configuration = config;
            _mapper = IMapper;
            _ILoginRepo = ILoginRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ApiResponse<LoginResponseDTO> Login([FromQuery] LoginRequestDTO request)
        {
            ApiResponse<LoginResponseDTO> response = new ApiResponse<LoginResponseDTO>();
            var result = _ILoginRepo.Login(request);
            if (result.UserId != null)
            {
                response.Data = result;
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                       // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                       // new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", Convert.ToString(result.UserId)),
                        new Claim("Email", result.Email),
                        new Claim("LoginId", Convert.ToString(result.LoginId)),
                       // new Claim("CoupleId", Convert.ToString(result.CoupleId)),
                        //new Claim("Email1", result.Email1),
                       // new Claim("Email2", result.Email2),

                       // new Claim("OrganizationId", Convert.ToString(result.OrganizationId)),

                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);

                result.Token = new JwtSecurityTokenHandler().WriteToken(token);

                response.Status = 1;

                return response;

                //JWT Settings End
            }
            response.Message = "Invalid Username Or Password!";
            response.Status = 0;
            return response;
        }
    }
}
