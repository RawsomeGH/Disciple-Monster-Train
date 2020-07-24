﻿using DiscipleClan.Triggers;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using static MonsterTrainModdingAPI.Constants.VanillaEnhancerPoolIDs;

namespace DiscipleClan.Enhancers
{
    class UnitUpgradeRelocate
    {
        public static string ID = "UnitUpgradeRelocate";

        public static void Make()
        {
            new EnhancerDataBuilder
            {
                ID = ID,
                ClanID = DiscipleClan.clanRef.GetID(),
                NameKey = ID + "_Name",
                DescriptionKey = ID + "_Desc",
                AssetPath = "Disciple/chrono/Enhancer/" + ID + ".png",
                Rarity = CollectableRarity.Common,
                CardType = CardType.Monster,
                EnhancerPoolIDs = new List<string> { UnitUpgradePoolCommon },
                Upgrade = new CardUpgradeDataBuilder
                {
                    UpgradeTitleKey = ID + "_Name",
                    UpgradeDescriptionKey = ID + "_CardDesc",
                    HideUpgradeIconOnCard = false,
                    UpgradeIcon = CustomAssetManager.LoadSpriteFromPath("Disciple/chrono/Enhancer/" + ID + ".png"),
                    TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                    {
                        new CharacterTriggerDataBuilder {
                            Trigger = OnRelocate.OnRelocateCharTrigger.GetEnum(),
                            EffectBuilders = new List<CardEffectDataBuilder>
                            {
                                new CardEffectDataBuilder
                                {
                                    EffectStateName = "CardEffectAddStatusEffect",
                                    TargetMode = TargetMode.Self,
                                    ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { statusId="gravity", count=1 } }
                                }
                            }
                        },
                    }
                },
            }.BuildAndRegister();
        }

    }
}