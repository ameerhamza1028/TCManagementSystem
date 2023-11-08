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
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public InsuranceRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllInsuranceResponseDTO> GetAllInsurance(long Id)
        {
            List<GetAllInsuranceResponseDTO> response = new List<GetAllInsuranceResponseDTO>();
            List<Insurance> list = _context.Insurances.Where(x => x.InsuranceId == Id).ToList();
            response = _mapper.Map<List<GetAllInsuranceResponseDTO>>(list);
            return response;
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
