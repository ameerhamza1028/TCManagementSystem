using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm13Repo
    {
        public bool SaveForm13(GetAllForm13RequestDTO request);
    }
}
