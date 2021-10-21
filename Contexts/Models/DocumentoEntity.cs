namespace Contexts.Models
{
    public class DocumentoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Fase_Id { get; set; }

        public FaseEntity Fase { get; set; }
    }
}
