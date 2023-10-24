using AutoMapper;
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
    public class UserRepo : IUserRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public UserRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<GetAllUserResponseDTO> GetAllUser()
        {
            List<GetAllUserResponseDTO> response = new List<GetAllUserResponseDTO>();
            List<User> list = _context.Users.ToList();
            response = _mapper.Map<List<GetAllUserResponseDTO>>(list);
            return response;
        }
        public bool SaveUser(GetAllUserRequestDTO request)
        {
            try
            {
                User User = new User();
                if (request.UserId == 0)
                {
                    User = _mapper.Map<User>(request);
                    _context.Users.Add(User);
                    _context.SaveChanges();
                }
                else
                {
                    User = _context.Users.Where(x => x.UserId == request.UserId).FirstOrDefault();
                    User = _mapper.Map(request, User);
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
