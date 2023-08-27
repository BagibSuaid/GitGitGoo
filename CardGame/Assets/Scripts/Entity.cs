using UnityEngine;

[System.Serializable]
public class Entity
{
    public delegate void EntityChangedHandler(Entity sender);
    public event EntityChangedHandler OnEntityChanged;

    [SerializeField]
    private int _health;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            OnEntityChanged?.Invoke(this);
        }
    }

    public int maxHealth;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}