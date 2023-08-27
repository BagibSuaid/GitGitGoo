using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card")]
[System.Serializable]
public class CardData : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public Cost cost;
    public List<CardEffect> cardEffects;
    public int damageNumber;
}