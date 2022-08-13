namespace MainProject.DAL.Models
{
    public class ArticleMaterial : Materials
    {
        public DateTime Date { get; set; }

        public string? Resource { get; set; }
    }
}
