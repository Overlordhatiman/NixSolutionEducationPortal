namespace MainProject.BL.DTO
{
    public class VideoDTO : MaterialsDTO
    {
        public int Time { get; set; }

        public string? Quality { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + Name + "\t" + Time.ToString() + "\t" + Quality + "\t";
        }
    }
}
