namespace MainProject.BL.DTO
{
    public class ArticleDTO : MaterialsDTO
    {
        public DateTime Date { get; set; }

        public string? Resource { get; set; }

        public override string? ToString()
        {
            return Name + "\t" + Date.ToString() + "\t" + Resource;
        }
    }
}
