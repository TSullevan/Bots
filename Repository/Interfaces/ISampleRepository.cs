namespace Repository.Interfaces
{
    public interface ISampleRepository<Entity>
    {
        public Entity Select(int id);
        public int Update(Entity entity);
    }
}
