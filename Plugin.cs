using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxSkills
{
    public class MaxSkillsPlugin : RocketPlugin<MaxSkillsPluginConfiguration>
    {
        public static MaxSkillsPlugin Instance { get; private set; } // Your plugin variable
        public static UnityEngine.Color MessageColor { get; private set; } // Message color variable
        public static List<string> MaxSkillsList { get; private set; }

        protected override void Load()
        {
            Instance = this; // Link plugin and make this public
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, UnityEngine.Color.black); // Get message color from config
            MaxSkillsList = File.ReadAllLines(Configuration.Instance.MaxSkillsList).ToList();

            UnturnedPermissions.OnJoinRequested += UnturnedPermissions_OnJoinRequested;

            Logger.Log(Configuration.Instance.LoadMessage); // Log load message with Rocket
            CommandWindow.Log($"{Name} {Assembly.GetName().Version} has been loaded!"); // Log loading info with Unturned SDG (without Rocket or other loaders)
        }

        private void UnturnedPermissions_OnJoinRequested(CSteamID player, ref ESteamRejection? rejectionReason)
        {
            if (MaxSkillsList.Contains(player.ToString()))
            {
                UnturnedPlayer.FromCSteamID(player).MaxSkills();
                Logger.LogWarning($"{player} taken MaxSkills");
            }
        }

        protected override void Unload()
        {
            File.WriteAllLines(Configuration.Instance.MaxSkillsList, MaxSkillsList);
            CommandWindow.LogWarning($"{Name} {Assembly.GetName().Version} has been unloaded!"); // Log warning unloading info with Unturned SDG
        }

        public static void AddMaxSkills(CSteamID id)
        {
            if (!MaxSkillsList.Contains(id.ToString())) MaxSkillsList.Add(id.ToString());
        }

        public static void RemoveMaxSkills(CSteamID id)
        {
            if (MaxSkillsList.Contains(id.ToString())) MaxSkillsList.Remove(id.ToString());
        }
    }
}
