using AutoMapper;
using PRJRepository.DTO.ClientNote;
using PRJRepository.DTO.EditClientDocument;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class EditClientDocumentRepo : IEditClientDocumentRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public EditClientDocumentRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EditClientDocumentResponseDTO> GetAllEditClientDocument(long Id)
        {
            List<EditClientDocumentResponseDTO> response = new List<EditClientDocumentResponseDTO>();
            List<EditClientDocument> list = _context.EditClientDocuments.Where(x => x.ClientId == Id && x.IsActive == true).ToList();
            foreach (var item in list)
            {
                EditClientDocumentResponseDTO document = new EditClientDocumentResponseDTO()
                {
                    Id = item.EditClientDocumentId,
                    Title = item.Title,
                    IssueDate = item.CreationDate,
                    ExpiryDate = item.Date,
                    Expire = "After 1 Month",
                    FileName = item.FileName,

                };
                response.Add(document);
            }
            return response;
        }

        public EditClientDocumentRequestDTO GetEditClientDocumentById(long Id)
        {
            EditClientDocumentRequestDTO response = new EditClientDocumentRequestDTO();
            EditClientDocument item = _context.EditClientDocuments.Where(x => x.EditClientDocumentId == Id).FirstOrDefault();
            response = _mapper.Map<EditClientDocumentRequestDTO>(item);
            return response;
        }

        public bool SaveEditClientDocument(EditClientDocumentRequestDTO request)
        {
            try
            {
                EditClientDocument EditClientDocument = new EditClientDocument();
                if (request.EditClientDocumentId == 0)
                {
                    EditClientDocument = _mapper.Map<EditClientDocument>(request);
                    EditClientDocument.IsActive = true;
                    EditClientDocument.CreationDate = DateTime.UtcNow;
                    _context.EditClientDocuments.Add(EditClientDocument);
                    _context.SaveChanges();
                }
                else
                {
                    EditClientDocument = _context.EditClientDocuments.Where(x => x.EditClientDocumentId == request.EditClientDocumentId).FirstOrDefault();
                    EditClientDocument = _mapper.Map(request, EditClientDocument);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteEditClientDocument(long Id)
        {
            try
            {
                EditClientDocument EditClientDocument = _context.EditClientDocuments.FirstOrDefault(x => x.EditClientDocumentId == Id);
                EditClientDocument.IsActive = false;
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
