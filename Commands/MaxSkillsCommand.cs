using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;

namespace MaxSkills.Commands
{
    public class MaxSkillsCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "maxskills";

        public string Help =>   "Use /maxskills for max your skills\n";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "skills.pass" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                ((UnturnedPlayer)caller).MaxSkills();
                UnturnedChat.Say(caller, "All skills maxed");
            }
        }
    }
}
