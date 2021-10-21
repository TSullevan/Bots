using Contexts.Models;
using Repository.Interfaces;

namespace Repository
{
    public class SampleRepository : ISampleRepository<DocumentoEntity>
    {
        public SampleRepository()
        {

        }

        public DocumentoEntity Select(int id)
        {
            return new DocumentoEntity();
        }

        public int Update(DocumentoEntity entity)
        {
            return 1;
        }
    }
}
