namespace GameZone.Models
{
    public class Category:BaseEntity
    {
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
