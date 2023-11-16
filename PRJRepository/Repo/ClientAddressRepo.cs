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

        public List<GetAllClientAddressResponseDTO> GetAllClientAddress(long Id)
        {
            List<GetAllClientAddressResponseDTO> response = new List<GetAllClientAddressResponseDTO>();
            List<Address> list = _context.Addresses.Where(x => x.ClientId == Id && x.IsActive == true).ToList();
            response = _mapper.Map<List<GetAllClientAddressResponseDTO>>(list);
            return response;
        }

        public bool DeleteClientAddress(long Id)
        {
            try
            {
                Address ClientAddress = _context.Addresses.FirstOrDefault(x => x.AddressId == Id);
                if (ClientAddress != null)
                {
                    ClientAddress.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
