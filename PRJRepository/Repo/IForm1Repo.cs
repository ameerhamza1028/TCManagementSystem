using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm1Repo
    {
        public bool SaveForm1(GetAllForm1RequestDTO request);
    }
}
