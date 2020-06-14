﻿using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Harmony;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ShinyShoe;
using MonsterTrainModdingAPI;

namespace MonsterTrainModdingAPI
{
    // Credit to Rawsome, Stable Infery for the base of this method.
    [BepInPlugin("com.name.package.generic", "Test Plugin", "0.1")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class TestPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony("com.name.package.generic");
            harmony.PatchAll();
        }
    }
}
