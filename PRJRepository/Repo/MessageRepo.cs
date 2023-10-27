using AutoMapper;
using PRJRepository.DTO.Message;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class MessageRepo : IMessageRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public MessageRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetMessageResponseDTO> GetAllMessage()
        {
            List<GetMessageResponseDTO> response = new List<GetMessageResponseDTO>();
            List<Models.Message> list = _context.Messages.ToList();
            response = _mapper.Map<List<GetMessageResponseDTO>>(list);
            return response;
        }

        public List<GetMessageResponseDTO> GetMessageById(long Id)
        {
            List<GetMessageResponseDTO> response = new List<GetMessageResponseDTO>();
            List<Message> list = _context.Messages.Where(x => x.MessageSenderId == Id).ToList();
            response = _mapper.Map<List<GetMessageResponseDTO>>(list);
            return response;
        }

        public bool SaveMessage(GetMessageRequestDTO request)
        {
            try
            {
                Models.Message Message = new Models.Message();
                Message = _mapper.Map<Models.Message>(request);
                Message.IsActive = true;
                Message.CreactionDate = DateTime.UtcNow;
                _context.Messages.Add(Message);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMessage(long Id)
        {
            try
            {
                List<Message> list = _context.Messages.Where(x => x.MessageSenderId == Id).ToList();
                foreach (var Message in list)
                {
                    Message.IsActive = false;
                }
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
