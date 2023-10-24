using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJRepository.DTO.ClientForm;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ClientFormRepo : IClientFormRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public ClientFormRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetAllClientFormResponseDTO GetClientFormById(long Id)
        {
            GetAllClientFormResponseDTO response = new GetAllClientFormResponseDTO();
            ClientForm item = _context.ClientForms.Where(x => x.FormId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllClientFormResponseDTO>(item);
            return response;
        }

        public bool SaveClientForm(GetAllClientFormRequestDTO request)
        {
            try
            {
                ClientForm ClientForm = new ClientForm();
                if (request.FormId == 0)
                {
                    ClientForm = _mapper.Map<ClientForm>(request);
                    ClientForm.CreationDate = DateTime.UtcNow;
                    ClientForm.FormJson = JsonSerializer.Serialize(request);
                    _context.ClientForms.Add(ClientForm);
                    _context.SaveChanges();
                }
                else
                {
                    ClientForm = _context.ClientForms.Where(x => x.FormId == request.FormId).FirstOrDefault();
                    if (ClientForm != null)
                    {
                        ClientForm = _mapper.Map(request, ClientForm);
                        ClientForm.FormJson = JsonSerializer.Serialize(request); 
                        _context.SaveChanges();
                    }
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
