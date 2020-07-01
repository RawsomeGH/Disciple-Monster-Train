﻿using DiscipleClan.Cards.CardEffects;
using MonsterTrainModdingAPI.Builders;
using MonsterTrainModdingAPI.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscipleClan.Cards.Upgrades
{
    class DiscipleRetainPro
    {
        public static string IDName = "RetainUpgradePro";
        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                upgradeTitleKey = IDName + "_Name",
                upgradeDescriptionKey = IDName + "_Desc",
                //upgradeNotificationKey = IDName + "_Notice",
                //upgradeIcon = CustomAssetManager.LoadSpriteFromPath("Disciple/chrono/Clan Assets/clan_32.png"),
                //hideUpgradeIconOnCard = false,
                useUpgradeHighlightTextTags = true,
                bonusDamage = 5,
                bonusHP = 25,
                //costReduction = 0,
                //xCostReduction = 0,
                //bonusHeal = 0,
                //bonusSize = 0,

                //traitDataUpgradeBuilders = new List<CardTraitDataBuilder> { },
                //triggerUpgradeBuilders = new List<CharacterTriggerDataBuilder> { },
                //cardTriggerUpgradeBuilders = new List<CardTriggerEffectDataBuilder> { },
                roomModifierUpgradeBuilders = new List<RoomModifierDataBuilder> 
                {
                    new RoomModifierDataBuilder
                    {
                    roomStateModifierClassName = typeof(RoomStateModifierHoldover).AssemblyQualifiedName,
                    paramInt = 3,
                    descriptionKey = IDName + "_Room",
                    extraTooltipTitleKey = IDName + "_RoomTipName",
                    extraTooltipBodyKey = IDName + "_RoomTipDesc",
                    }
                },
                //filtersBuilders = new List<CardUpgradeMaskDataBuilder> { },
                //upgradesToRemoveBuilders = new List<CardUpgradeDataBuilder> { },
                //statusEffectUpgrades = new List<StatusEffectStackData> { },
            };

            return railtie;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }

    }
}