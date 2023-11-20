using AutoMapper;
using PRJRepository.DTO.ImportClient;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class ImportClientRepo : IImportClientRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public ImportClientRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllImportClientResponseDTO> GetAllImportClient()
        {
            List<GetAllImportClientResponseDTO> response = new List<GetAllImportClientResponseDTO>();
            List<ImportClient> list = _context.ImportClients.Where(x => x.IsActive == true).ToList();
            foreach (var item in list)
            {
                GetAllImportClientResponseDTO import = new GetAllImportClientResponseDTO()
                {
                    ImportClientId = item.ImportClientId,
                    Name = item.FirstName + " " + item.LastName,
                    FilePath = item.FileUploadPath,
                    FileName = item.FileName,
                    Clinician = _context.Clinicians.Where(x => x.ClinicianId == item.PrimaryClinicianId).Select(x => x.ClinicianName).FirstOrDefault(),
                    ClientEmail = item.ClientEmail,
                    Intake = item.Intake,
                    DateAdded = item.CreationDate,

                };
                response.Add(import);
                
            }
            return response;
        }

        public GetAllImportClientRequestDTO GetImportClientById(long Id)
        {
            GetAllImportClientRequestDTO response = new GetAllImportClientRequestDTO();
            ImportClient item = _context.ImportClients.Where(x => x.ImportClientId == Id && x.IsActive == true).FirstOrDefault();
            response = _mapper.Map<GetAllImportClientRequestDTO>(item);
            return response;
        }

        public bool SaveImportClient(GetAllImportClientRequestDTO request)
        {
            try
            {
                ImportClient ImportClient = new ImportClient();
                if (request.ImportClientId == 0)
                {
                    ImportClient = _mapper.Map<ImportClient>(request);
                    ImportClient.IsActive = true;
                    ImportClient.CreationDate = DateTime.UtcNow;
                    _context.ImportClients.Add(ImportClient);
                    _context.SaveChanges();
                }
                else
                {
                    ImportClient = _context.ImportClients.Where(x => x.ImportClientId == request.ImportClientId).FirstOrDefault();
                    ImportClient = _mapper.Map(request, ImportClient);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteImportClient(long Id)
        {
            try
            {
                ImportClient ImportClient = _context.ImportClients.FirstOrDefault(x => x.ImportClientId == Id);
                if (ImportClient != null)
                {
                    ImportClient.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }

        }
    }
}
