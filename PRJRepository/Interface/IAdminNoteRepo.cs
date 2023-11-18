using PRJRepository.DTO.ClientNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IAdminNoteRepo
    {
        public List<GetAllAdminNoteResponseDTO> GetAllAdminNote(long Id);
        public GetAllAdminNoteRequestDTO GetAdminNoteById(long Id);
        public bool SaveAdminNote(GetAllAdminNoteRequestDTO request);
        public bool DeleteAdminNote(long Id);
    }
}
