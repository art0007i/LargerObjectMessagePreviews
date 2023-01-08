using HarmonyLib;
using NeosModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using System.Reflection.Emit;

namespace LargerObjectMessagePreviews
{
    public class LargerObjectMessagePreviews : NeosMod
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
        [HarmonyPatch(typeof(FriendsDialog), "AddMessage")]
        class LargerObjectMessagePreviewsPatch
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes)
            {
                foreach (var code in codes)
                {
                    if(code.Is(OpCodes.Ldc_I4_S, 64))
                    {
                        yield return new CodeInstruction(OpCodes.Ldc_I4, 256);
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