﻿using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.Interface;
using PRJRepository.Models;
using System.Text;

namespace PRJRepository.Repo
{
    public class ClientRepo : IClientRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ClientRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllClientResponseDTO> GetAllClient()
        {
            List<GetAllClientResponseDTO> response = new List<GetAllClientResponseDTO>();
            List<Models.Client> list = _context.Clients.ToList();
            response = _mapper.Map<List<GetAllClientResponseDTO>>(list);
            return response;
        }

        public GetAllClientResponseDTO GetClientById(long Id)
        {
            GetAllClientResponseDTO response = new GetAllClientResponseDTO();
            Models.Client item = _context.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllClientResponseDTO>(item);
            return response;
        }

        public bool SaveClient(GetAllClientRequestDTO request)
        {
            try
            {
                Models.Client client = new Models.Client();
                if (request.ClientId == 0)
                {
                    client = _mapper.Map<Models.Client>(request);
                    client.IsActive = true;
                    client.CreatedDate = DateTime.UtcNow;
                    _context.Clients.Add(client);
                    _context.SaveChanges();

                }
                else
                {
                    client = _context.Clients.Where(x => x.ClientId == request.ClientId).FirstOrDefault();
                    client = _mapper.Map(request, client);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClient(long Id)
        {
            try
            {
               Client client = _context.Clients.FirstOrDefault(x => x.ClientId == Id);
               client.IsActive = false;
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
