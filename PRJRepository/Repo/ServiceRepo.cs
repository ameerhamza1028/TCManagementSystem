using AutoMapper;
using PRJRepository.DTO.Service;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ServiceRepo : IServiceRepo
        {
            private readonly TcemrProdContext _context;
            private readonly IMapper _mapper;
            public ServiceRepo(TcemrProdContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public List<GetAllServiceResponseDTO> GetAllService(long Id)
            {
                List<GetAllServiceResponseDTO> response = new List<GetAllServiceResponseDTO>();
                List<Service> list = _context.Services.Where(x => x.ServiceId == Id).ToList();
            response = _mapper.Map<List<GetAllServiceResponseDTO>>(list);
                return response;
            }

            public bool DeleteService(long Id)
            {
                try
                {
                    Service Service = _context.Services.FirstOrDefault(x => x.ServiceId == Id);
                    Service.IsActive = false;
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
