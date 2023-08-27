//DiscardSelfEffect.cs
using UnityEngine;

[CreateAssetMenu(fileName = "DiscardSelf", menuName = "Cards/Discard Self")]
public class DiscardSelfEffect : CardEffect
{
    public override void ExecuteEffect(EffectContext context)
    {
        var hand = context.combat.hand;
        var self = context.card;
        if(!hand.Contains(self))
        {
            Debug.LogWarning("card no longer in hand!");
            return;
        }
        hand.Remove(self);
        context.combat.discardPile.Add(self);
    }
}