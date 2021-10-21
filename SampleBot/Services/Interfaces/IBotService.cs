using Contexts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleBot.Services.Interfaces
{
    public interface IBotService
    {
        public Task<IEnumerable<DocumentoEntity>> GetDocumentsByPhase(int phaseId);
        public Task MoveToNextPhase(IEnumerable<DocumentoEntity> documents, int nextPhase);
    }
}
