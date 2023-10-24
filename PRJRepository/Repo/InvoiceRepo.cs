using AutoMapper;
using PRJRepository.DTO.Invoice;
using PRJRepository.Interface;
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

        public GetAllInvoiceResponseDTO GetInvoiceById(long Id)
        {
            GetAllInvoiceResponseDTO response = new GetAllInvoiceResponseDTO();
            Invoice item = _context.Invoices.Where(x => x.InvoiveId == Id).FirstOrDefault();
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

        public bool DeleteInvoice(long Id)
        {
            try
            {
                Invoice invoice = _context.Invoices.FirstOrDefault(x => x.InvoiveId == Id);
                invoice.IsActive = false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
