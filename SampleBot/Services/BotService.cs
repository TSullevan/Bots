using Contexts.Models;
using Repository.Interfaces;
using SampleBot.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleBot.Services
{
    public class BotService : IBotService
    {
        IDocumentoRepository _documentoRepository;
        public BotService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<IEnumerable<DocumentoEntity>> GetDocumentsByPhase(int phaseId)
        {
            return await _documentoRepository.SelectByPhase(phaseId);
        }

        public async Task MoveToNextPhase(IEnumerable<DocumentoEntity> documents, int nextPhase)
        {
            foreach (DocumentoEntity document in documents)
            {
                document.Fase_Id = nextPhase;
                await _documentoRepository.UpdateAsync(document);
            }
        }
    }
}
