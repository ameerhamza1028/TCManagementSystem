using AutoMapper;
using PRJRepository.DTO;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly TcdatabaseContext _context;
        private readonly IMapper _mapper;
        public InvoiceRepo(TcdatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllInvoiceResponseDTO> GetAllInvoice()
        {
            List<GetAllInvoiceResponseDTO> response = new List<GetAllInvoiceResponseDTO>();
            List<Invoice> list = _context.Invoices.ToList();
            response = _mapper.Map<List<GetAllInvoiceResponseDTO>>(list);
            return response;
        }

        public GetAllInvoiceResponseDTO GetInvoiceById(long id)
        {
            GetAllInvoiceResponseDTO response = new GetAllInvoiceResponseDTO();
            Invoice item = _context.Invoices.Where(x => x.InvoiveId == id).FirstOrDefault();
            response = _mapper.Map<GetAllInvoiceResponseDTO>(item);
            return response;
        }

        public bool SaveInvoice(GetAllInvoiceRequestDTO request)
        {
            try
            {
                Invoice Invoice = new Invoice();
                if (request.InvoiveId == 0)
                {
                    Invoice = _mapper.Map<Invoice>(request);
                    _context.Invoices.Add(Invoice);
                    _context.SaveChanges();
                }
                else
                {
                    Invoice = _context.Invoices.Where(x => x.InvoiveId == request.InvoiveId).FirstOrDefault();
                    Invoice = _mapper.Map(request, Invoice);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInvoice(long id)
        {
            try
            {
                var Invoice = _context.Invoices.FirstOrDefault(x => x.InvoiveId == id);
                _context.Invoices.Remove(Invoice);
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
