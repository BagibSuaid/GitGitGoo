//EnemyController.cs
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public TMP_Text text;
    public Entity entity;

    private void Awake()
    {
        UpdateText(entity);
        entity.OnEntityChanged += UpdateText;

    }
    private void OnDestroy()
    {
        entity.OnEntityChanged -= UpdateText;
    }

    void UpdateText(Entity entity)
    {
        text.text = $"{entity.Health} / {entity.maxHealth}";
    }
}