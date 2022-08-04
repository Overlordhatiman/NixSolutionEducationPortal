namespace MainProject.src.Models
{
    public class BookMaterial : Materials
    {
        public string? Author { get; set; }

        public int NumberOfPages { get; set; }

        public string? Format { get; set; }

        public DateTime Date { get; set; }
    }
}
