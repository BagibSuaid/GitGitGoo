//CardEffect.cs
using System;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public abstract class CardEffect : ScriptableObject
{
    public abstract void ExecuteEffect(EffectContext context);
}

public class EffectContext
{
    public Card card;
    public Entity target;
    public Combat combat;
}