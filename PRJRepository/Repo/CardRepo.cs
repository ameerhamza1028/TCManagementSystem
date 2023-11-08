using AutoMapper;
using PRJRepository.DTO.Card;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class CardRepo : ICardRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public CardRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllCardResponseDTO> GetAllCard(long Id)
        {
            List<GetAllCardResponseDTO> response = new List<GetAllCardResponseDTO>();
            List<Card> list = _context.Cards.Where(x => x.CardId == Id).ToList();
            response = _mapper.Map<List<GetAllCardResponseDTO>>(list);
            return response;
        }

        public bool DeleteCard(long Id)
        {
            try
            {
                Card Card = _context.Cards.FirstOrDefault(x => x.CardId == Id);
                Card.IsActive = false;
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
