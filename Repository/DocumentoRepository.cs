using Contexts.Models;
using Dapper;
using Repository.Connections.Interfaces;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private IDbConnection _dapperConnection { get; set; }
        public DocumentoRepository(ISampleConnection dbConnection)
        {
            _dapperConnection = dbConnection;
        }

        public async Task<IEnumerable<DocumentoEntity>> SelectByPhase(int phaseId)
        {
            var query = new StringBuilder();
            query.Append($"SELECT * FROM Documentos left join Fases on Documentos.Fase_Id = Fases.Id WHERE Fase_Id = {phaseId}");

            DynamicParameters parameters = new();

            return (await _dapperConnection.QueryAsync<DocumentoEntity, FaseEntity, DocumentoEntity>(
                sql: query.ToString(),
                map: (documentoEntity, faseEntity) =>
                {
                    documentoEntity.Fase = faseEntity ?? null;
                    return documentoEntity;
                },
                param: parameters
                ));
        }
        public async Task<IEnumerable<DocumentoEntity>> Select(int id)
        {
            var query = new StringBuilder();
            query.Append($"SELECT * FROM Documentos left join Fases on Documentos.Fase_Id = Fases.Id WHERE Id = {id}");

            DynamicParameters parameters = new();

            return (await _dapperConnection.QueryAsync<DocumentoEntity, FaseEntity, DocumentoEntity>(
                sql: query.ToString(),
                map: (documentoEntity, faseEntity) =>
                {
                    documentoEntity.Fase = faseEntity ?? null;
                    return documentoEntity;
                },
                param: parameters
                ));
        }

        public async Task<int> UpdateAsync(DocumentoEntity entity)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@Id", entity.Id },
                { "@Descricao", entity.Descricao },
                { "@Fase_Id", entity.Fase_Id }
            };

            return await _dapperConnection.ExecuteAsync("UPDATE Documentos SET Descricao=@Descricao, Fase_Id=@Fase_Id WHERE Id=@Id;", new DynamicParameters(parameters));
        }
    }
}
