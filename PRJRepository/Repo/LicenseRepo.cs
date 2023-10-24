using AutoMapper;
using PRJRepository.DTO.License;
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
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public LicenseRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllLicenseResponseDTO> GetAllLicense()
        {
            List<GetAllLicenseResponseDTO> response = new List<GetAllLicenseResponseDTO>();
            List<License> list = _context.Licenses.ToList();
            response = _mapper.Map<List<GetAllLicenseResponseDTO>>(list);
            return response;
        }

        public bool SaveLicense(GetAllLicenseRequestDTO request)
        {
            try
            {
                License License = new License();
                if (request.LicenseId == 0)
                {
                    License = _mapper.Map<License>(request);
                    License.IsActive = true;
                    License.CreationDate = DateTime.UtcNow;
                    _context.Licenses.Add(License);
                    _context.SaveChanges();
                }
                else
                {
                    License = _context.Licenses.Where(x => x.LicenseId == request.LicenseId).FirstOrDefault();
                    License = _mapper.Map(request, License);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLicense(long Id)
        {
            try
            {
                License License = _context.Licenses.FirstOrDefault(x => x.LicenseId == Id);
                License.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
