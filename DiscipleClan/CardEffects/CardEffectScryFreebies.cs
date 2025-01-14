﻿using Trainworks.Builders;

namespace DiscipleClan.CardEffects
{
    class CardEffectScryFreebies : CardEffectScry
    {
        public override void AddDelegate(CardEffectState cardEffectState,
          CardEffectParams cardEffectParams,
          DeckScreen deckScreen)
        {
            deckScreen.AddDeckScreenCardStateChosenDelegate((DeckScreen.CardStateChosenDelegate)(chosenCardState =>
            {
                chosenCardState.AddTemporaryTrait(new CardTraitDataBuilder { TraitStateName = "CardTraitFreebie", ParamInt = -99 }.Build(), cardEffectParams.cardManager);
                cardEffectParams.screenManager.SetScreenActive(ScreenName.Deck, false, (ScreenManager.ScreenActiveCallback)null);
            }));
        }

        public override string GetTooltipBaseKey()
        {
            return "ScreenDeck_Select_CardEffectRecursion";
        }

    }
}
