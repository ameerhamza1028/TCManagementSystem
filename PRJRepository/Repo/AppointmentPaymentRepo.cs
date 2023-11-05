using AutoMapper;
using PRJRepository.DTO.AppointmentPayment;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class AppointmentPaymentRepo : IAppointmentPaymentRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public AppointmentPaymentRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllAppointmentPaymentResponseDTO> GetAllAppointmentPayment()
        {
            List<GetAllAppointmentPaymentResponseDTO> response = new List<GetAllAppointmentPaymentResponseDTO>();
            List<AppointmentPayment> list = _context.AppointmentPayments.ToList();
            response = _mapper.Map<List<GetAllAppointmentPaymentResponseDTO>>(list);
            return response;
        }

        public GetAllAppointmentPaymentResponseDTO GetAppointmentPaymentById(long Id)
        {
            GetAllAppointmentPaymentResponseDTO response = new GetAllAppointmentPaymentResponseDTO();
            AppointmentPayment item = _context.AppointmentPayments.Where(x => x.AppointmentPaymentId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllAppointmentPaymentResponseDTO>(item);
            return response;
        }

        public bool SaveAppointmentPayment(GetAllAppointmentPaymentRequestDTO request)
        {
            try
            {
                AppointmentPayment AppointmentPayment = new AppointmentPayment();
                if (request.AppointmentPaymentId == 0)
                {
                    AppointmentPayment = _mapper.Map<AppointmentPayment>(request);
                    AppointmentPayment.IsActive = true;
                    AppointmentPayment.CreationDate = DateTime.UtcNow;
                    _context.AppointmentPayments.Add(AppointmentPayment);
                    _context.SaveChanges();
                }
                else
                {
                    AppointmentPayment = _context.AppointmentPayments.Where(x => x.AppointmentPaymentId == request.AppointmentPaymentId).FirstOrDefault();
                    AppointmentPayment = _mapper.Map(request, AppointmentPayment);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAppointmentPayment(long Id)
        {
            try
            {
                AppointmentPayment AppointmentPayment = _context.AppointmentPayments.FirstOrDefault(x => x.AppointmentPaymentId == Id);
                AppointmentPayment.IsActive = false;
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
