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

        protected override void Load()
        {
            Instance = this; // Link plugin and make this public
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, UnityEngine.Color.black); // Get message color from config

            Logger.Log(Configuration.Instance.LoadMessage); // Log load message with Rocket
            CommandWindow.Log($"{Name} {Assembly.GetName().Version} has been loaded!"); // Log loading info with Unturned SDG (without Rocket or other loaders)
        }

        protected override void Unload()
        {
            CommandWindow.LogWarning($"{Name} {Assembly.GetName().Version} has been unloaded!"); // Log warning unloading info with Unturned SDG
        }
    }
}
