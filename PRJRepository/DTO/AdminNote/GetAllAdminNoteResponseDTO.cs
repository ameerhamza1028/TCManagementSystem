﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.DTO.ClientNote
{
    public class GetAllAdminNoteResponseDTO
    {
        public long NoteId { get; set; }

        public long? ClientId { get; set; }

        public string? NoteTitle { get; set; }

        public string? Note { get; set; }
    }
}
