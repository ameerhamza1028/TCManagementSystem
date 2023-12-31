﻿using PRJRepository.DTO.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface ICardRepo
    {
        public List<GetAllCardResponseDTO> GetAllCard(long Id);
        public bool DeleteCard(long Id);
    }
}
