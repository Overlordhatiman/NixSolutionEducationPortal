namespace MainProject.BL.DTO
{
    public class BookDTO : MaterialsDTO
    {
        public string? Author { get; set; }

        public int NumberOfPages { get; set; }

        public string? Format { get; set; }

        public DateTime Date { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + Name + "\t" + Date.ToString() + "\t" + Author + "\t" + NumberOfPages + "\t" + Format;
        }
    }
}
