﻿using AutoMapper;
using PRJRepository.DTO.BillingSetting;
using PRJRepository.Interface;
using PRJRepository.Models;

namespace PRJRepository.Repo
{
    public class BillingSettingRepo : IBillingSettingRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public BillingSettingRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAllBillingSettingResponseDTO GetBillingSettingById(long Id)
        {
            GetAllBillingSettingResponseDTO response = new GetAllBillingSettingResponseDTO();
            BillingSetting item = _context.BillingSettings.Where(x => x.BillingId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllBillingSettingResponseDTO>(item);
            return response;
        }

        public bool SaveBillingSetting(GetAllBillingSettingRequestDTO request)
        {
            try
            {
                BillingSetting BillingSetting = new BillingSetting();
                if (request.BillingId == 0)
                {
                    BillingSetting = _mapper.Map<BillingSetting>(request);
                    BillingSetting.IsActive = true;
                    BillingSetting.CreationDate = DateTime.UtcNow;
                    _context.BillingSettings.Add(BillingSetting);
                    _context.SaveChanges();
                }
                else
                {
                    BillingSetting = _context.BillingSettings.Where(x => x.BillingId == request.BillingId).FirstOrDefault();
                    BillingSetting = _mapper.Map(request, BillingSetting);
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
