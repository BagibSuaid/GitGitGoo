using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{

    Combat combat;
    public CardCollection deck;
    public List<Entity> enemies;

    void Awake()
    {
        combat = new Combat(deck, enemies);
    }
}