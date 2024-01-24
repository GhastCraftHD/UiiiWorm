using HarmonyLib;

namespace UiiiWorm.Patches
{
    [HarmonyPatch(typeof(SandWormAI))]
    internal class SandWormAIPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void OverrideAudio(SandWormAI __instance)
        {
            __instance.emergeFromGroundSFX = UiiiWorm.SoundFX[0];
        }    
    }
}