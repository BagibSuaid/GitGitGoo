//DrawEffect.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Draw", menuName = "Cards/Draw")]
public class DrawEffect : CardEffect
{
    public override void ExecuteEffect(EffectContext context)
    {
        context.combat.DrawCard();
    }
}