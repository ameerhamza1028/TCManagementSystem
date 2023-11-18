using AutoMapper;
using PRJRepository.DTO.ClientNote;
using PRJRepository.Interface;
using PRJRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class AdminNoteRepo : IAdminNoteRepo
    {
        private readonly TcemrProdContext _context;
        private readonly IMapper _mapper;
        public AdminNoteRepo(TcemrProdContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAllAdminNoteResponseDTO> GetAllAdminNote(long Id)
        {
            List<GetAllAdminNoteResponseDTO> response = new List<GetAllAdminNoteResponseDTO>();
            List<AdminNote> list = _context.AdminNotes.Where(x => x.ClientId == Id && x.IsActive == true).ToList();
            foreach (var item in list)
            {
                GetAllAdminNoteResponseDTO note = new GetAllAdminNoteResponseDTO()
                {
                    Note = item.Note,
                };
                response.Add(note);
                
            }
            return response;
        }

        public GetAllAdminNoteRequestDTO GetAdminNoteById(long Id)
        {
            GetAllAdminNoteRequestDTO response = new GetAllAdminNoteRequestDTO();
            AdminNote item = _context.AdminNotes.Where(x => x.NoteId == Id).FirstOrDefault();
            response = _mapper.Map<GetAllAdminNoteRequestDTO>(item);
            return response;
        }

        public bool SaveAdminNote(GetAllAdminNoteRequestDTO request)
        {
            try
            {
                AdminNote AdminNote = new AdminNote();
                if (request.NoteId == 0)
                {
                    AdminNote = _mapper.Map<AdminNote>(request);
                    AdminNote.IsActive = true;
                    AdminNote.CreactionDate = DateTime.UtcNow;
                    _context.AdminNotes.Add(AdminNote);
                    _context.SaveChanges();
                }
                else
                {
                    AdminNote = _context.AdminNotes.Where(x => x.NoteId == request.NoteId).FirstOrDefault();
                    AdminNote = _mapper.Map(request, AdminNote);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteAdminNote(long Id)
        {
            try
            {
                AdminNote AdminNote = _context.AdminNotes.FirstOrDefault(x => x.NoteId == Id);
                AdminNote.IsActive = false;
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
