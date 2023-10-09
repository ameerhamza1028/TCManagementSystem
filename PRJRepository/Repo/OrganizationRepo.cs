using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.EntityModel;

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

        public GetAllOrganizationResponseDTO GetOrganizationById(int id)
        {
            GetAllOrganizationResponseDTO response = new GetAllOrganizationResponseDTO();
            Organization item = _context.Organizations.Where(x => x.OrgId == id).FirstOrDefault();
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

        public bool DeleteOrganization(int id)
        {
            try
            {
                var organization = _context.Organizations.Where(x => x.OrgId == id).FirstOrDefault();
                //organization = _mapper.Map<Organization>(id);
                _context.Organizations.Remove(organization);
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
