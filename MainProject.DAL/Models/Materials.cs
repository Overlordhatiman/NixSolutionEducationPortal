
namespace MainProject.src.Models
{
    abstract public class Materials
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Materials()
        {

        }

        public Materials(string name)
        {
            Name = name;
        }
    }
}
