namespace Foxus.Domain
{
    public class Tarefa
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual bool Finalizada { get; set; }
    }
}
