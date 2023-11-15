using PRJRepository.DTO.ImportClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Interface
{
    public interface IImportClientRepo
    {
        public List<GetAllImportClientResponseDTO> GetAllImportClient();
        public GetAllImportClientRequestDTO GetImportClientById(long Id);
        public bool SaveImportClient(GetAllImportClientRequestDTO request);
        public bool DeleteImportClient(long Id);
    }
}
