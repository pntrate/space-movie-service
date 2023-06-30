namespace Movies.Domain
{
	public class Entity
	{
		public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = new Guid();
        }
    }
}
