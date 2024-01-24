using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UiiiWorm.Patches;
using UnityEngine;

namespace UiiiWorm
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class UiiiWorm : BaseUnityPlugin
    {
        private const String modGUID = "GhastCraftHD.UiiiWorm";
        private const String modName = "UiiiWorm";
        private const String modVersion = "1.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static UiiiWorm instance;

        internal ManualLogSource mls;

        internal static AudioClip[] SoundFX;
        internal static AssetBundle bundle;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            
            mls.LogInfo("UiiiWorm was enabled");

            String folderPath = instance.Info.Location;
            folderPath = folderPath.TrimEnd("UiiiWorm.dll".ToCharArray());
            bundle = AssetBundle.LoadFromFile(folderPath + "uiiiworm");
            if (bundle != null)
            {
                mls.LogInfo("Loaded asset bundle successfully");
                SoundFX = bundle.LoadAllAssets<AudioClip>();
            }
            else
            {
                mls.LogInfo("Failed to load asset bundle");
            }


            harmony.PatchAll(typeof(UiiiWorm));
            harmony.PatchAll(typeof(SandWormAIPatch));
        }
    }
}