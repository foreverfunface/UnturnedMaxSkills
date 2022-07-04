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

        public string Help =>   "Use /maxskills for max your skills\n" +
                                "Use /maxskills + [Username] for add autoskill for user\n" +
                                "Or /maxskills - [UserName] for remove from this list\n" +
                                "Use /maxskills l to get autoskill users list";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "skills.pass" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 0)
            {
                ((UnturnedPlayer)caller).MaxSkills();
                UnturnedChat.Say(caller, "All skills maxed");
            }
            else
            {
                if (command[0] == "+")
                {
                    MaxSkillsPlugin.AddMaxSkills(UnturnedPlayer.FromName(command[1]).CSteamID);
                }
                else if (command[0] == "-")
                {
                    MaxSkillsPlugin.RemoveMaxSkills(UnturnedPlayer.FromName(command[1]).CSteamID);
                }
                else if (command[0] == "l" || command[0] == "list")
                {
                    UnturnedChat.Say(caller, "AutoMaxSkill users:");
                    foreach(var user in MaxSkillsPlugin.MaxSkillsList) UnturnedChat.Say(caller, $"{user}");
                }
            }
        }
    }
}
