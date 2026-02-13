namespace Mission06_Pead.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
