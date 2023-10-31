using AutoMapper;
using PRJRepository.DTO.Insurance;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class InsuranceRepo : IInsuranceRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public InsuranceRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllInsuranceResponseDTO> GetAllInsurance()
        {
            List<GetAllInsuranceResponseDTO> response = new List<GetAllInsuranceResponseDTO>();
            List<Models.Insurance> list = _context.Insurances.ToList();
            response = _mapper.Map<List<GetAllInsuranceResponseDTO>>(list);
            return response;
        }

        public bool SaveInsurance(GetAllInsuranceRequestDTO request)
        {
            try
            {
                Models.Insurance Insurance = new Models.Insurance();
                if (request.InsuranceId == 0)
                {
                    Insurance = _mapper.Map<Models.Insurance>(request);
                    Insurance.IsActive = true;
                    Insurance.CreationDate = DateTime.UtcNow;
                    _context.Insurances.Add(Insurance);
                    _context.SaveChanges();
                }
                else
                {
                    Insurance = _context.Insurances.Where(x => x.InsuranceId == request.InsuranceId).FirstOrDefault();
                    Insurance = _mapper.Map(request, Insurance);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInsurance(long Id)
        {
            try
            {
                Insurance Insurance = _context.Insurances.FirstOrDefault(x => x.InsuranceId == Id);
                Insurance.IsActive = false;
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
