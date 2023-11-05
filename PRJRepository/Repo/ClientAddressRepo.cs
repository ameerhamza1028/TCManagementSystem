using AutoMapper;
using PRJRepository.DTO.ClientAddress;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ClientAddressRepo : IClientAddressRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ClientAddressRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllClientAddressResponseDTO> GetAllClientAddress()
        {
            List<GetAllClientAddressResponseDTO> response = new List<GetAllClientAddressResponseDTO>();
            List<Models.Address> list = _context.Addresses.ToList();
            response = _mapper.Map<List<GetAllClientAddressResponseDTO>>(list);
            return response;
        }

        public bool SaveClientAddress(GetAllClientAddressRequestDTO request)
        {
            try
            {
                Models.Address ClientAddress = new Models.Address();
                if (request.AddressId == 0)
                {
                    ClientAddress = _mapper.Map<Models.Address>(request);
                    ClientAddress.IsActive = true;
                    ClientAddress.CreationDate = DateTime.UtcNow;
                    _context.Addresses.Add(ClientAddress);
                    _context.SaveChanges();
                }
                else
                {
                    ClientAddress = _context.Addresses.Where(x => x.AddressId == request.AddressId).FirstOrDefault();
                    ClientAddress = _mapper.Map(request, ClientAddress);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClientAddress(long Id)
        {
            try
            {
                Address ClientAddress = _context.Addresses.FirstOrDefault(x => x.AddressId == Id);
                ClientAddress.IsActive = false;
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
