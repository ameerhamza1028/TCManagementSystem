using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class EditClientRepo : IEditClientRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public EditClientRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EditClientResponseDTO GetEditClient(long Id)
        {
            EditClientResponseDTO response = new EditClientResponseDTO();
            Models.EditClient item = _context.EditClients.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<EditClientResponseDTO>(item);
            return response;
        }

        public SaveEditClientContactResponseDTO GetEditClientContact(long Id)
        {
            SaveEditClientContactResponseDTO response = new SaveEditClientContactResponseDTO();
            Models.EditClientContact item = _context.EditClientContacts.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<SaveEditClientContactResponseDTO>(item);
            return response;
        }

        public SaveEditClientBillingResponseDTO GetEditClientBilling(long Id)
        {
            SaveEditClientBillingResponseDTO response = new SaveEditClientBillingResponseDTO();
            Models.EditClientBilling item = _context.EditClientBillings.Where(x => x.ClientId == Id).FirstOrDefault();
            response = _mapper.Map<SaveEditClientBillingResponseDTO>(item);
            return response;
        }

        public bool SaveClient(SaveEditClientRequestDTO request)
        {
            try
            {
                EditClient edit = new EditClient();
                Client client = _context.Clients.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (client != null) {
                    edit = _mapper.Map<Models.EditClient>(request);
                    edit.ModifiedDate = DateTime.UtcNow;
                    _context.EditClients.Add(edit);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }

                List<Phone1DTO> PhoneList = request.Phone;
                foreach (var list in PhoneList)
                {
                    Phone phone;

                    if (list.PhoneId == 0)
                    {
                        phone = _mapper.Map<Phone>(list);
                        phone.ClientId = edit.ClientId;
                        phone.IsActive = true;
                        phone.CreactionDate = DateTime.UtcNow;
                        _context.Phones.Add(phone);
                    }
                    else
                    {
                        phone = _context.Phones.FirstOrDefault(x => x.PhoneId == list.PhoneId);

                        if (phone != null)
                        {
                            _mapper.Map(list, phone);
                        }
                    }
                }

                List<Address1DTO> AddressList = request.Address;
                foreach (var list in AddressList)
                {
                    Address address;

                    if (list.AddressId == 0)
                    {
                        address = _mapper.Map<Address>(list);
                        address.ClientId = edit.ClientId;
                        address.IsActive = true;
                        address.CreationDate = DateTime.UtcNow;
                        _context.Addresses.Add(address);
                    }
                    else
                    {
                        address = _context.Addresses.FirstOrDefault(x => x.AddressId == list.AddressId);

                        if (address != null)
                        {
                            _mapper.Map(list, address);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        public bool SaveClientContact(SaveEditClientContactRequestDTO request)
        {
            try
            {
                EditClient edit = new EditClient();
                EditClientContact editcontact = new EditClientContact();
                Client client = _context.Clients.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (client != null)
                {
                    editcontact = _mapper.Map<Models.EditClientContact>(request);
                    //editcontact.ModifiedDate = DateTime.UtcNow;
                    _context.EditClientContacts.Add(editcontact);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }

                List<Phone2DTO> PhoneList = request.Phone;
                foreach (var list in PhoneList)
                {
                    Phone phone;

                    if (list.PhoneId == 0)
                    {
                        phone = _mapper.Map<Phone>(list);
                        phone.ClientId = edit.ClientId;
                        phone.IsActive = true;
                        phone.CreactionDate = DateTime.UtcNow;
                        _context.Phones.Add(phone);
                    }
                    else
                    {
                        phone = _context.Phones.FirstOrDefault(x => x.PhoneId == list.PhoneId);

                        if (phone != null)
                        {
                            _mapper.Map(list, phone);
                        }
                    }
                }

                List<ContactEmailDTO> ContactEmailList = request.ContactEmail;
                foreach (var list in ContactEmailList)
                {
                    Email contactEmail;

                    if (list.EmailId == 0)
                    {
                        contactEmail = _mapper.Map<Email>(list);
                        contactEmail.ClientId = edit.ClientId;
                        contactEmail.IsActive = true;
                        contactEmail.CreationDate = DateTime.UtcNow;
                        _context.Emails.Add(contactEmail);
                    }
                    else
                    {
                        contactEmail = _context.Emails.FirstOrDefault(x => x.EmailId == list.EmailId);

                        if (contactEmail != null)
                        {
                            _mapper.Map(list, contactEmail);
                        }
                    }
                }

                List<Address2DTO> AddressList = request.Address;
                foreach (var list in AddressList)
                {
                    Address address;

                    if (list.AddressId == 0)
                    {
                        address = _mapper.Map<Address>(list);
                        address.ClientId = edit.ClientId;
                        address.IsActive = true;
                        address.CreationDate = DateTime.UtcNow;
                        _context.Addresses.Add(address);
                    }
                    else
                    {
                        address = _context.Addresses.FirstOrDefault(x => x.AddressId == list.AddressId);

                        if (address != null)
                        {
                            _mapper.Map(list, address);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SaveClientBilling(SaveEditClientBillingRequestDTO request)
        {
            try
            {
                EditClient edit = new EditClient();
                EditClientBilling editbilling = new EditClientBilling();
                Client client = _context.Clients.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (client != null)
                {
                    editbilling = _mapper.Map<Models.EditClientBilling>(request);
                    //editcontact.ModifiedDate = DateTime.UtcNow;
                    _context.EditClientBillings.Add(editbilling);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }

                List<CardDTO> CardList = request.Card;
                foreach (var list in CardList)
                {
                    Card card;

                    if (list.CardId == 0)
                    {
                        card = _mapper.Map<Card>(list);
                        card.ClientId = edit.ClientId;
                        card.IsActive = true;
                        card.CreationDate = DateTime.UtcNow;
                        _context.Cards.Add(card);
                    }
                    else
                    {
                        card = _context.Cards.FirstOrDefault(x => x.CardId == list.CardId);

                        if (card != null)
                        {
                            _mapper.Map(list, card);
                        }
                    }
                }

                List<InsuranceDTO> InsuranceList = request.Insurance;
                foreach (var list in InsuranceList)
                {
                    Insurance Insurance;

                    if (list.InsuranceId == 0)
                    {
                        Insurance = _mapper.Map<Insurance>(list);
                        Insurance.ClientId = edit.ClientId;
                        Insurance.IsActive = true;
                        Insurance.CreationDate = DateTime.UtcNow;
                        _context.Insurances.Add(Insurance);
                    }
                    else
                    {
                        Insurance = _context.Insurances.FirstOrDefault(x => x.InsuranceId == list.InsuranceId);

                        if (Insurance != null)
                        {
                            _mapper.Map(list, Insurance);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }   }
