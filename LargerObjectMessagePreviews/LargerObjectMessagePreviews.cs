using HarmonyLib;
using ResoniteModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using System.Reflection.Emit;

namespace LargerObjectMessagePreviews
{
    public class LargerObjectMessagePreviews : ResoniteMod
    {
        public override string Name => "LargerObjectMessagePreviews";
        public override string Author => "art0007i";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/art0007i/LargerObjectMessagePreviews/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("me.art0007i.LargerObjectMessagePreviews");
            harmony.PatchAll();

        }
        [HarmonyPatch(typeof(ContactsDialog), "AddMessage")]
        class LargerObjectMessagePreviewsPatch
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes)
            {
                var found = false;
                foreach (var code in codes)
                {
                    if(!found && code.Is(OpCodes.Ldc_R4, 64.0f))
                    {
                        found = true;
                        yield return new CodeInstruction(OpCodes.Ldc_R4, 256.0f);
                    }
                    else
                    {
                        yield return code;
                    }
                }
            }
        }
    }
}