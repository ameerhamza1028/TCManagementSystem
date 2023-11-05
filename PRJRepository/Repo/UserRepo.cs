﻿using AutoMapper;
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


        public List<GetAllUserResponseDTO> GetAllUser()
        {
            List<GetAllUserResponseDTO> response = new List<GetAllUserResponseDTO>();
            List<TcUser> list = _context.TcUsers.ToList();
            response = _mapper.Map<List<GetAllUserResponseDTO>>(list);
            return response;
        }

        public GetAllUserResponseDTO GetUserById(long Id)
        {
            GetAllUserResponseDTO response = new GetAllUserResponseDTO();
            Models.TcUser item = _context.TcUsers.Where(x => x.UserId == Id).FirstOrDefault();
            if (item != null)
            {
               // response.LastLoginDate = _context.Logins.Where(x => x.LoginId == item.LoginId).Select(x => x.CreationDate).FirstOrDefault();                
                response.UserId = item.UserId;
                response.UserName = item.UserName;
                response.UserType = item.UserType;
                response.Status = item.Status;
                response.Email = item.Email;
                response.Phone = item.Phone;
                response.CreationDate = item.CreationDate;
            }

            return response;
        }
        public bool SaveUser(GetAllUserRequestDTO request)
        {
            try
            {
                TcUser User = new TcUser();
                if (request.UserId == 0)
                {
                    User = _mapper.Map<TcUser>(request);
                    User.IsActive = true;
                    User.CreationDate = DateTime.UtcNow;
                    _context.TcUsers.Add(User);
                    _context.SaveChanges();

                }
                else
                {
                    User = _context.TcUsers.Where(x => x.UserId == request.UserId).FirstOrDefault();
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
        public bool DeleteUser(long Id)
        {
            try
            {
                TcUser user = _context.TcUsers.FirstOrDefault(x => x.UserId == Id);
                user.IsActive = false;
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
