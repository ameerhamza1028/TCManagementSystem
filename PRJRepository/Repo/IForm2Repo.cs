using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm2Repo
    {
        public bool SaveForm2(GetAllForm2RequestDTO request);
    }
}
