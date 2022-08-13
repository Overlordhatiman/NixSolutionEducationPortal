namespace MainProject.BL.DTO
{
    public class ArticleDTO : MaterialsDTO
    {
        public DateTime Date { get; set; }

        public string? Resource { get; set; }

        public override string? ToString()
        {
            return Date.ToString() + "\t" + Resource;
        }
    }
}
