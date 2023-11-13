using AutoMapper;
using PRJRepository.DTO.Client;
using PRJRepository.DTO.EditClient;
using PRJRepository.DTO.User;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public List<GetAllEditClientContactResponse> GetAllEditClientContact(long Id)
        {
            List<GetAllEditClientContactResponse> response = new List<GetAllEditClientContactResponse>();
            List<Models.EditClientContact> list = _context.EditClientContacts.Where(x => x.ClientId == Id).ToList();
            foreach (var contact in list)
            {
                GetAllEditClientContactResponse clientResponse = new GetAllEditClientContactResponse
                {
                    ContactId = contact.ContactId,
                    ContactFirstName = contact.ContactFirstName,
                    ContactLastName = contact.ContactLastName,
                    ContactSuffix = contact.ContactSuffix,
                    ContactEmail = contact.ConatactEmail,
                    ContactRelationshipStatus = contact.ContactRelationshipStatus,
                    IsEmergencyContact = contact.IsEmergencyContact,
                    ContactPhone = _context.Phones.Where(x => x.ClientId == contact.ClientId).Select(x => x.PhoneNumber).FirstOrDefault(),
                    ContactAdress = _context.Addresses.Where(x => x.ClientId == contact.ClientId).Select(x => x.Address1).FirstOrDefault(),
                };
                response.Add(clientResponse);
            }
            return response;
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
            Models.EditClientContact item = _context.EditClientContacts.Where(x => x.ContactId == Id).FirstOrDefault();
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
                edit = _context.EditClients.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (edit != null)
                {
                    List<Phone1DTO> PhoneList = request.Phone;
                    foreach (var list in PhoneList)
                    {
                        Phone phone = new Phone();

                        if (list.PhoneId == 0)
                        {
                            phone = _mapper.Map<Phone>(list);
                            phone.ClientId = edit.ClientId;
                            phone.IsActive = true;
                            phone.CreactionDate = DateTime.UtcNow;
                            _context.Phones.Add(phone);
                            _context.SaveChanges();
                        }
                        else
                        {
                            phone = _context.Phones.FirstOrDefault(x => x.PhoneId == list.PhoneId);

                            if (phone != null)
                            {
                                _mapper.Map(list, phone);
                                _context.SaveChanges();
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
                            address.ContactId = 0;
                            _context.Addresses.Add(address);
                            _context.SaveChanges();
                        }
                        else
                        {
                            address = _context.Addresses.FirstOrDefault(x => x.AddressId == list.AddressId);

                            if (address != null)
                            {
                                _mapper.Map(list, address);
                                _context.SaveChanges();
                            }
                        }
                    }
                    _mapper.Map(request, edit);
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


        public bool SaveClientContact(SaveEditClientContactRequestDTO request)
        {
            try
            {
                EditClient edit = new EditClient();
                EditClientContact editcontact = new EditClientContact();
                    if (request.ContactId == 0)
                    {
                        editcontact = _mapper.Map<EditClientContact>(request);
                        editcontact.IsActive = true;
                        _context.EditClientContacts.Add(editcontact);
                        _context.SaveChanges();
                    }
                    else
                    {
                        editcontact = _context.EditClientContacts.Where(x => x.ContactId == request.ContactId).FirstOrDefault();
                        _mapper.Map(request, editcontact);
                        _context.SaveChanges();
                    }
                    List<Phone2DTO> PhoneList = request.Phone;
                    foreach (var list in PhoneList)
                    {
                        Phone phone;

                        if (list.PhoneId == 0)
                        {
                            phone = _mapper.Map<Phone>(list);
                            phone.ClientId = editcontact.ClientId;
                            phone.ContactId = editcontact.ContactId;
                            phone.IsActive = true;
                            phone.CreactionDate = DateTime.UtcNow;
                            _context.Phones.Add(phone);
                            _context.SaveChanges();
                        }
                        else
                        {
                            phone = _context.Phones.FirstOrDefault(x => x.PhoneId == list.PhoneId);

                            if (phone != null)
                            {
                                _mapper.Map(list, phone);
                                _context.SaveChanges();
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
                        address.ClientId = editcontact.ClientId;
                        address.IsActive = true;
                        address.CreationDate = DateTime.UtcNow;
                        address.ContactId = editcontact.ContactId;
                        _context.Addresses.Add(address);
                        _context.SaveChanges();
                    }
                    else
                    {
                        address = _context.Addresses.FirstOrDefault(x => x.AddressId == list.AddressId);

                        if (address != null)
                        {
                            _mapper.Map(list, address);
                            _context.SaveChanges();
                        }
                    }
                }
                return true;

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
                editbilling = _context.EditClientBillings.Where(c => c.ClientId == request.ClientId).FirstOrDefault();
                if (editbilling != null)
                {
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
                            _context.SaveChanges();
                        }
                        else
                        {
                            card = _context.Cards.FirstOrDefault(x => x.CardId == list.CardId);

                            if (card != null)
                            {
                                _mapper.Map(list, card);
                                _context.SaveChanges();
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
                                _context.SaveChanges();
                            }
                        }
                    }
                    _mapper.Map(request, editbilling);
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

        public bool DeleteClientContact(long Id)
        {
            try
            {
                EditClientContact editclientcontact = _context.EditClientContacts.FirstOrDefault(x => x.ContactId == Id);
                editclientcontact.IsActive = false;
                _context.SaveChanges();

                Phone phone = _context.Phones.FirstOrDefault(x => x.ContactId == Id);
                editclientcontact.IsActive = false;
                _context.SaveChanges();

                Address address = _context.Addresses.FirstOrDefault(x => x.ContactId == Id);
                editclientcontact.IsActive = false;
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
