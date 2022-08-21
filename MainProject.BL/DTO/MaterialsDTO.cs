namespace MainProject.BL.DTO
{
    public class MaterialsDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + Name + "\t";
        }
    }
}
