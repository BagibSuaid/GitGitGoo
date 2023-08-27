// DragHandler.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(LayoutElement))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturnTo = null;
    GameObject placeholder = null;
    public GameObject placeholderPrefab = null;

    private CanvasGroup canvasGroup;
    private RectTransform handRectTransform;
    private List<IDraggable> draggables;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        handRectTransform = transform.parent.GetComponent<RectTransform>();
        draggables = new List<IDraggable>(GetComponents<IDraggable>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = Instantiate(placeholderPrefab);
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        placeholder.transform.localPosition = transform.localPosition;
        placeholder.transform.localScale = transform.localScale;
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        canvasGroup.blocksRaycasts = false;

        foreach (var item in draggables)
        {
            item.OnBeginDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = parentToReturnTo.childCount;

        for (int i = 0; i < parentToReturnTo.childCount; i++)
        {
            if (this.transform.position.x < parentToReturnTo.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);

        foreach (var item in draggables)
        {
            item.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        canvasGroup.blocksRaycasts = true;

        if (!RectTransformUtility.RectangleContainsScreenPoint(handRectTransform, eventData.position))
        {
            //OnCardDraggedOutOfBounds();
        }

        Destroy(placeholder);
        foreach (var item in draggables)
        {
            item.OnEndDrag(eventData);
        }
    }

    private void OnDestroy() {
        if(placeholder!=null)
        {
            Destroy(placeholder);
        }
    }




}

public interface IDraggable
{
    public void OnBeginDrag(PointerEventData eventData);
    public void OnDrag(PointerEventData eventData);
    public void OnEndDrag(PointerEventData eventData);

}