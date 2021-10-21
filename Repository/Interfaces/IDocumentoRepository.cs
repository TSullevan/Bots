using Contexts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDocumentoRepository
    {
        public Task<IEnumerable<DocumentoEntity>> SelectByPhase(int phaseId);
        public Task<IEnumerable<DocumentoEntity>> Select(int id);
        public Task<int> UpdateAsync(DocumentoEntity entity);
    }
}
