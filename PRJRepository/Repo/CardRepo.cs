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
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public CardRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllCardResponseDTO> GetAllCard()
        {
            List<GetAllCardResponseDTO> response = new List<GetAllCardResponseDTO>();
            List<Models.Card> list = _context.Cards.ToList();
            response = _mapper.Map<List<GetAllCardResponseDTO>>(list);
            return response;
        }

        public bool SaveCard(GetAllCardRequestDTO request)
        {
            try
            {
                Models.Card Card = new Models.Card();
                if (request.CardId == 0)
                {
                    Card = _mapper.Map<Models.Card>(request);
                    Card.IsActive = true;
                    Card.CreationDate = DateTime.UtcNow;
                    _context.Cards.Add(Card);
                    _context.SaveChanges();
                }
                else
                {
                    Card = _context.Cards.Where(x => x.CardId == request.CardId).FirstOrDefault();
                    Card = _mapper.Map(request, Card);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
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
