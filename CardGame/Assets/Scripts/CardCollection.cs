using System.Collections.ObjectModel;
using UnityEngine;

public class CardCollection : ObservableCollection<Card>
{
    public CardCollection(CardCollection other = null) : base(other) { }

    public void Shuffle()
    {
        int n = Count;
        for (int i = n - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            (this[r], this[i]) = (this[i], this[r]);
        }
    }

    public Card Pop()
    {
        var list = this;
        if (list.Count == 0)
        {
            return default;
        }

        Card item = list[^1];
        list.RemoveAt(list.Count - 1);
        return item;
    }
}