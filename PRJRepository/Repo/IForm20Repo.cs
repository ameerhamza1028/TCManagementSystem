using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm20Repo
    {
        public bool SaveForm20(GetAllForm20RequestDTO request);
    }
}
