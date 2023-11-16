using AutoMapper;
using PRJRepository.DTO.License;
using PRJRepository.DTO.Message;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class LicenseRepo : ILicenseRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public LicenseRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllLicenseResponseDTO> GetLicenseById(long Id)
        {
            List<GetAllLicenseResponseDTO> response = new List<GetAllLicenseResponseDTO>();
            List<License> list = _context.Licenses.Where(x => x.UserId == Id && x.IsActive == true).ToList();
            response = _mapper.Map<List<GetAllLicenseResponseDTO>>(list);
            return response;
        }


        public bool DeleteLicense(long Id)
        {
            try
            {
                License License = _context.Licenses.FirstOrDefault(x => x.LicenseId == Id);
                if (License != null)
                {
                    License.IsActive = false;
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
