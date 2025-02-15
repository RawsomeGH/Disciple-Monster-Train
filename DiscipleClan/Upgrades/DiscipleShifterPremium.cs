﻿using DiscipleClan.Triggers;
using Trainworks.Builders;
using System.Collections.Generic;

namespace DiscipleClan.Upgrades
{
    class DiscipleShifterPremium
    {
        public static string IDName = "ShifterUpgradePremium";
        public static int buffAmount = 4;
        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                //upgradeNotificationKey = IDName + "_Notice",
                //upgradeIcon = CustomAssetManager.LoadSpriteFromPath("Clan Assets/clan_32.png"),
                //HideUpgradeIconOnCard = false,
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 20,
                BonusHP = 10,
                //costReduction = 0,
                //xCostReduction = 0,
                //bonusHeal = 0,
                //BonusSize = 0,

                //traitDataUpgradeBuilders = new List<CardTraitDataBuilder> { },
                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    // Shifter
                    //new CharacterTriggerDataBuilder
                    //{
                    //    Trigger = CharacterTriggerData.Trigger.EndTurnPreHandDiscard,
                    //    EffectBuilders = new List<CardEffectDataBuilder>
                    //    {
                    //        new CardEffectDataBuilder
                    //        {
                    //            EffectStateName = typeof(ShinyShoe.CardEffectTeleport).AssemblyQualifiedName,
                    //            TargetMode = TargetMode.Self,
                    //            TargetTeamType = Team.Type.Heroes,
                    //        }
                    //    }
                    //},

                    // Buff everyone on the floor when we shift
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = OnRelocate.OnRelocateCharTrigger.GetEnum(),
                        DescriptionKey = IDName + "_Desc",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateName = "CardEffectAddTempCardUpgradeToUnits",
                                ParamCardUpgradeData = new CardUpgradeDataBuilder {
                                     BonusDamage = buffAmount,
                                }.Build(),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            },
                            new CardEffectDataBuilder
                            {
                                EffectStateName = "CardEffectAddTempCardUpgradeToUnits",
                                ParamCardUpgradeData = new CardUpgradeDataBuilder {
                                     BonusHP = buffAmount
                                }.Build(),
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Monsters,
                            },
                        }
                    },
                },
                //cardTriggerUpgradeBuilders = new List<CardTriggerEffectDataBuilder> { },
                //RoomModifierUpgradeBuilders = new List<RoomModifierDataBuilder> { },
                //filtersBuilders = new List<CardUpgradeMaskDataBuilder> { },
                //upgradesToRemoveBuilders = new List<CardUpgradeDataBuilder> { },
                //StatusEffectUpgrades = new List<StatusEffectStackData> { },
            };

            return railtie;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }

    }
}