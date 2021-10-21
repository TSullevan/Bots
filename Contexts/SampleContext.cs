using Contexts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contexts
{
    public class SampleContext : DbContext
    {
        public virtual DbSet<FaseEntity> Fases { get; set; }
        public virtual DbSet<DocumentoEntity> Documentos { get; set; }
        public SampleContext(DbContextOptions<SampleContext> config) : base(config)
        {

        }
    }
}
