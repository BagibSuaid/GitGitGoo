using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combat
{
    static readonly int maxHandSize = 10;
    public CardCollection drawPile;
    public CardCollection discardPile;
    public CardCollection hand;
    public List<Entity> enemies;

    public int turnCounter;

    public Combat(CardCollection deck, List<Entity> enemies)
    {
        drawPile = new CardCollection(deck);
        drawPile.Shuffle();
        discardPile = new CardCollection();
        hand = new CardCollection();
        this.enemies = enemies;
        turnCounter = 0;
    }

    void StartNewTurn()
    {
        turnCounter++;
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }


    public void DrawCard()
    {
        if (hand.Count >= maxHandSize)
        {
            Debug.LogWarning("hand too full");
            return;
        }
        if (drawPile.Count == 0)
        {
            (drawPile, discardPile) = (discardPile, drawPile);
            drawPile.Shuffle();
        }
        if (drawPile.Count == 0)
        {
            Debug.Log("draw AND discard empty");
            return;
        }
        hand.Add(drawPile.Pop());
    }
}