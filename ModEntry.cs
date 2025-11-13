using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace PermanentBookseller
{
    public class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(this.ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(Utility), nameof(Utility.getDaysOfBooksellerThisSeason)),
                postfix: new HarmonyMethod(typeof(ModEntry), nameof(Postfix))
            );

            this.Config = this.Helper.ReadConfig<ModConfig>();
            bool exampleBool = this.Config.ExampleBoolean;
        }

        public static void Postfix(ref List<int> __result)
        {
            __result = Enumerable.Range(1, 28).ToList();
        }
    }
}

