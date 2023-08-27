//DamageEffect.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Cards/Damage")]
public class DamageEffect : CardEffect
{
    public override void ExecuteEffect(EffectContext context)
    {
        var target = context.target;
        var card = context.card;
        if(target == null || card == null)
        {
            Debug.LogError($"target is {target}, card is {card}");
            return;
        }
        target.TakeDamage(card.cardData.damageNumber);
    }
}