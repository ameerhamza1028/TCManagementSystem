using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm18Repo
    {
        public bool SaveForm18(GetAllForm18RequestDTO request);
    }
}
