﻿using Trainworks.Builders;
using Trainworks.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using static Trainworks.Constants.VanillaEnhancerPoolIDs;

namespace DiscipleClan.Enhancers
{
    class UnitUpgradeAdapter
    {
        public static string ID = "UnitUpgradeAdapter";

        public static void Make()
        {
            new EnhancerDataBuilder
            {
                ID = ID,
                //ClanID = DiscipleClan.clanRef.GetID(),
                NameKey = ID + "_Name",
                DescriptionKey = ID + "_Desc",
                AssetPath = "Enhancer/" + ID + ".png",
                Rarity = CollectableRarity.Uncommon,
                CardType = CardType.Monster,
                EnhancerPoolIDs = new List<string> { UnitUpgradePool },
                Upgrade = new CardUpgradeDataBuilder
                {
                    UpgradeTitleKey = ID + "_Name",
                    UpgradeDescriptionKey = ID + "_CardDesc",
                    HideUpgradeIconOnCard = false,
                    UpgradeIconPath = "Enhancer/" + ID + ".png",
                    StatusEffectUpgrades = new List<StatusEffectStackData>
                    {
                        new StatusEffectStackData
                        {
                            statusId = "adapted",
                            count = 1,
                        }
                    },
                    FiltersBuilders = new List<CardUpgradeMaskDataBuilder>
                    {
                        new CardUpgradeMaskDataBuilder
                        {
                            CardType = CardType.Monster,
                            UpgradeDisabledReason = CardState.UpgradeDisabledReason.NotEligible,
                            ExcludeNonAttackingMonsters = true,
                        }
                    }
                },
            }.BuildAndRegister();
        }

    }
}
