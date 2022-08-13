﻿namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Newtonsoft.Json;

    public class FileSkillRepository : ISkillRepository
    {
        private List<Skill>? _skills;

        public FileSkillRepository()
        {
            string str = File.ReadAllText(DALConstant.SkillFilePath);

            _skills = JsonConvert.DeserializeObject<List<Skill>>(str);
        }

        public Skill AddSkill(Skill skill)
        {
            _skills?.Add(skill);

            return skill;
        }

        public bool DeleteSkill(int id)
        {
            return _skills.Remove(_skills.Find(x => x.Id == id));
        }

        public IEnumerable<Skill> GetAllSkill()
        {
            return _skills;
        }

        public Skill UpdateSkill(int id, Skill skill)
        {
            int index = _skills.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new Skill();
            }

            _skills[index] = skill;

            return skill;
        }

        public async Task Save()
        {
            var str = JsonConvert.SerializeObject(_skills, Formatting.Indented);

            await File.WriteAllTextAsync(DALConstant.SkillFilePath, str);
        }
    }
}
