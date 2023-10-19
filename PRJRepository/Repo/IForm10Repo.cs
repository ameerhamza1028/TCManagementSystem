using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm10Repo
    {
        public bool SaveForm10(GetAllForm10RequestDTO request);
    }
}
