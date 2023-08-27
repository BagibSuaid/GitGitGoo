//DeckController.cs
using System.Collections.Generic;
using UnityEngine;

public class CardsInHandController : MonoBehaviour
{
    public Combat combat;
    public Transform hand;
    public List<CardController> cardsInHand;
    [SerializeField]
    GameObject cardPrefab;

    public void UpdateDisplay()
    {
        foreach (var card in combat.hand)
        {
            if (cardsInHand.Exists((cardInHand) => cardInHand.card == card))
            {
                continue;
            }
            var cardGO = Instantiate(cardPrefab, hand);
            if (!cardGO.TryGetComponent<CardController>(out var cardController))
            {
                Debug.LogError("card prefab doesn't contain a CardController");
                return;
            }
            cardController.Initialize(combat, card);
            cardsInHand.Add(cardController);
        }
        var excessCards = cardsInHand.FindAll((cardInHand) => !combat.hand.Contains(cardInHand.card));
        foreach (var cardInHand in excessCards)
        {
            cardsInHand.Remove(cardInHand);
            Destroy(cardInHand.gameObject);
        }
    }

    private void Awake()
    {
        UpdateDisplay();
    }
    public void DrawCard()
    {
        combat.DrawCard();
        UpdateDisplay();
    }
}