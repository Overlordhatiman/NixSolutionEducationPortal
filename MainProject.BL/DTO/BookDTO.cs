namespace MainProject.BL.DTO
{
    public class BookDTO : MaterialsDTO
    {
        public string? Author { get; set; }

        public int NumberOfPages { get; set; }

        public string? Format { get; set; }

        public DateTime Date { get; set; }
    }
}
