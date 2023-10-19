using PRJRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public interface IForm15Repo
    {
        public bool SaveForm15(GetAllForm15RequestDTO request);
    }
}
