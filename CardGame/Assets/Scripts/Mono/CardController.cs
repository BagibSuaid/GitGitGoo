//CardController.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DragHandler))]
public class CardController : MonoBehaviour, IDraggable
{
    public Card card;
    public Combat combat;

    public void Initialize(Combat combat, Card newCard)
    {
        card = newCard;

        this.combat = combat;
        // Update the card's appearance based on the cardData
    }

    public void PlayCard(Entity target)
    {
        var context = new EffectContext
        {
            card = card,
            combat = combat,
            target = target
        };

        foreach (CardEffect effect in card.cardData.cardEffects)
        {
            effect.ExecuteEffect(context);
        }
    }

    void IDraggable.OnBeginDrag(PointerEventData eventData) { }

    void IDraggable.OnDrag(PointerEventData eventData) { }

    void IDraggable.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("cardDropped?");
        var pointer = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        foreach (var result in raycastResults)
        {
            var hit = result.gameObject;
            if (hit.transform.TryGetComponent<EnemyController>(out var entity))
            {
                PlayCard(entity.entity);
                return;
            }
            Debug.Log($"hit, but no entity: {hit.name}");
        }

    }

}
