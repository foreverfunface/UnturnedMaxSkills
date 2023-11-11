using System;
using System.Linq;
using System.Threading.Tasks;
using OpenMod.API.Permissions;
using OpenMod.Core.Commands;
using OpenMod.Core.Console;
using OpenMod.Core.Permissions;
using OpenMod.Unturned.Users;

namespace MaxSkillsPlugin.Commands
{
    [Command("maxskills")]
    [CommandDescription("Set your skills to max LVL")]
    [CommandAlias("ms")]
    [RegisterCommandPermission("skills.permission", Description = "Set your skills to max LVL", DefaultGrant = PermissionGrantResult.Deny)]
    [CommandActor(typeof(UnturnedUser))]
    public class MaxSkills : Command
	{
        private readonly MaxSkillsPlugin m_MyPlugin;
        public MaxSkills(
         MaxSkillsPlugin myPlugin,
         IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_MyPlugin = myPlugin;
        }

        protected override async Task OnExecuteAsync()
        {
            //SDG.Unturned.PlayerTool.getPlayer(Context.Actor.DisplayName).skills.ServerUnlockAllSkills();//.skills.ServerModifyExperience(500000);
            SDG.Unturned.Player NativePlayer = SDG.Unturned.PlayerTool.getPlayer(Context.Actor.DisplayName);

            SDG.Unturned.PlayerSkills skills = NativePlayer.skills;

            foreach (SDG.Unturned.Skill skill in skills.skills.SelectMany(s => s)) skill.level = skill.max;

            skills.askSkills(NativePlayer.channel.owner.playerID.steamID);
        }
    }
}

