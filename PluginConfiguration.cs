using Rocket.API;

namespace MaxSkills
{
    public class MaxSkillsPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string LoadMessage { get; set; }
        public string MaxSkillsList { get; set; }
        public string AddAutoCommand { get; set; }
        public string RemoveAutoCommand { get; set; }
        public void LoadDefaults()
        {
            MessageColor = "green";
            LoadMessage = "MaxSkills is active!\nGet more plugins on https://vk.com/astis.unturned.store";
        }
    }
}
