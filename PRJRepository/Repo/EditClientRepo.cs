using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class EditClientRepo : IEditClientRepo
    {
        private readonly TcemrProdContext   _context;
        private readonly IMapper _mapper;
        public EditClientRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveClient(SaveEditClientRequestDTO request)
        {
            try
            {
                EditClient edit = new EditClient();
                Client client = _context.Clients.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (client != null) {
                    edit = _mapper.Map<Models.EditClient>(request);
                    edit.ModifiedDate = DateTime.UtcNow;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }
                
            }
            catch
            {
                return false;
            }
        }
    }
}
