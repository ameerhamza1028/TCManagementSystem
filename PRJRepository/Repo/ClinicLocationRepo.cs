using AutoMapper;
using PRJRepository.DTO.ClinicLocation;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class ClinicLocationRepo : IClinicLocationRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ClinicLocationRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAllClinicLocationRequestDTO GetClinicLocationById(long Id)
        {
            GetAllClinicLocationRequestDTO response = new GetAllClinicLocationRequestDTO();
            ClinicLocation item = _context.ClinicLocations.Where(x => x.ClinicId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllClinicLocationRequestDTO>(item);
            return response;
        }

        public bool SaveClinicLocation(GetAllClinicLocationRequestDTO request)
        {
            try
            {
                ClinicLocation ClinicLocation = new ClinicLocation();
                if (request.ClinicLocationId == 0)
                {
                    ClinicLocation = _mapper.Map<ClinicLocation>(request);
                    ClinicLocation.IsActive = true;
                    ClinicLocation.CreationDate = DateTime.UtcNow;
                    if(request.BillingAddress == "SameAsFacility")
                    {
                        Clinic clinic = _context.Clinics.Where(x => x.ClinicId ==  request.ClinicId).FirstOrDefault();
                        ClinicLocation.Address1 = clinic.Address;
                        ClinicLocation.CountryId1 = clinic.CountryId;
                        ClinicLocation.StateId1 = clinic.StateId;
                        ClinicLocation.CityId1 = clinic.CityId;
                        ClinicLocation.ZipCode1 = clinic.ZipCode;

                    }
                    _context.ClinicLocations.Add(ClinicLocation);
                    _context.SaveChanges();
                }
                else
                {
                    ClinicLocation = _context.ClinicLocations.Where(x => x.ClinicLocationId == request.ClinicLocationId).FirstOrDefault();
                    ClinicLocation = _mapper.Map(request, ClinicLocation);
                    if (request.BillingAddress == "SameAsFacility")
                    {
                        Clinic clinic = _context.Clinics.Where(x => x.ClinicId == request.ClinicId).FirstOrDefault();
                        ClinicLocation.Address1 = clinic.Address;
                        ClinicLocation.CountryId1 = clinic.CountryId;
                        ClinicLocation.StateId1 = clinic.StateId;
                        ClinicLocation.CityId1 = clinic.CityId;
                        ClinicLocation.ZipCode1 = clinic.ZipCode;

                    }
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
