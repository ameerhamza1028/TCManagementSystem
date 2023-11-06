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
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public LicenseRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAllLicenseResponseDTO GetLicenseById(long Id)
        {
            GetAllLicenseResponseDTO response = new GetAllLicenseResponseDTO();
            License item = _context.Licenses.Where(x => x.LicenseId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllLicenseResponseDTO>(item);
            return response;
        }

        public bool SaveLicense(GetAllLicenseRequestDTO request)
        {
            try
            {
                TcUser user = new TcUser();
                License License = new License();
                if (request.LicenseId == 0)
                {
                    License = _mapper.Map<License>(request);
                    License.UserId = user.UserId;
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
