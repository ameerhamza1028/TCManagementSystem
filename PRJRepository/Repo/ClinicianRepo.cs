using AutoMapper;
using PRJRepository.DTO.Clinician;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ClinicianRepo : IClinicianRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ClinicianRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAllClinicianResponseDTO> GetAllClinician()
        {
            List<GetAllClinicianResponseDTO> response = new List<GetAllClinicianResponseDTO>();
            List<Models.Clinician> list = _context.Clinicians.ToList();
            response = _mapper.Map<List<GetAllClinicianResponseDTO>>(list);
            return response;
        }
    }
}
