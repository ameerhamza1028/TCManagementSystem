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

            public List<GetAllServiceResponseDTO> GetAllService()
            {
                List<GetAllServiceResponseDTO> response = new List<GetAllServiceResponseDTO>();
                List<Models.Service> list = _context.Services.ToList();
                response = _mapper.Map<List<GetAllServiceResponseDTO>>(list);
                return response;
            }

            public bool SaveService(GetAllServiceRequestDTO request)
            {
                try
                {
                    Models.Service Service = new Models.Service();
                    if (request.ServiceId == 0)
                    {
                        Service = _mapper.Map<Models.Service>(request);
                        Service.IsActive = true;
                        Service.CreationDate = DateTime.UtcNow;
                        _context.Services.Add(Service);
                        _context.SaveChanges();
                    }
                    else
                    {
                        Service = _context.Services.Where(x => x.ServiceId == request.ServiceId).FirstOrDefault();
                        Service = _mapper.Map(request, Service);
                        _context.SaveChanges();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
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
