using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTest : MonoBehaviour
{
    public GameObject tooltipPrefab;
    public Transform canvas;
    public Transform buttonParent;
    public GameObject button;
    static GameObject tooltip;

    public void onPress()
    {
        if (canvas == null)
        {
            canvas = transform.parent.parent;
        }
        if (tooltip != null)
        {
            Destroy(tooltip);
        }
        tooltip = Instantiate(tooltipPrefab, canvas);
        var tooltipTransform = tooltip.GetComponent<RectTransform>();
        tooltipTransform.anchoredPosition = RectTransformUtility.CalculateRelativeRectTransformBounds(canvas.transform, transform).center;
        tooltipTransform.anchoredPosition = new Vector2(tooltipTransform.anchoredPosition.x, tooltipTransform.anchoredPosition.y + GetComponent<RectTransform>().rect.height);
    }

    public void createButton()
    {
        Instantiate(button, buttonParent);
    }

}
