using MainProject.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface ISkillRepository
    {
        public Skill AddSkill(Skill skill);
        public Skill UpdateSkill(int id, Skill skill);
        public List<Skill> GetAllSkill();
        public bool DeleteSkill(Skill skill);
    }
}
