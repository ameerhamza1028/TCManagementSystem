using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm4Repo
    {
        public bool SaveForm4(GetAllForm4RequestDTO request);
    }
}
