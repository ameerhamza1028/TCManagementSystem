using AutoMapper;
using PRJRepository.DTO.Organization;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class OrganizationRepo : IOrganizationRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public OrganizationRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllOrganizationResponseDTO> GetAllOrganization()
        {
            List<GetAllOrganizationResponseDTO> response = new List<GetAllOrganizationResponseDTO>();
            List<Organization> list = _context.Organizations.ToList();
            response = _mapper.Map<List<GetAllOrganizationResponseDTO>>(list);
            return response;
        }

        public GetAllOrganizationResponseDTO GetOrganizationById(long Id)
        {
            GetAllOrganizationResponseDTO response = new GetAllOrganizationResponseDTO();
            Organization item = _context.Organizations.Where(x => x.OrgId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllOrganizationResponseDTO>(item);
            return response;
        }

        public bool SaveOrganization(GetAllOrganizationRequestDTO request)
        {
            try
            {
                Organization organization = new Organization();
                if (request.OrgId == 0)
                {
                    organization = _mapper.Map<Organization>(request);
                    _context.Organizations.Add(organization);
                    _context.SaveChanges();
                }
                else
                {
                    organization = _context.Organizations.Where(x => x.OrgId == request.OrgId).FirstOrDefault();
                    _mapper.Map(request, organization);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrganization(long Id)
        {
            try
            {
                Organization organization = _context.Organizations.Where(x => x.OrgId == Id).FirstOrDefault();
                organization.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
