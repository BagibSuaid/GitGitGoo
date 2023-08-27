using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public static class ObservableCollectionExtensions
{
    public static void Shuffle<T>(this ObservableCollection<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            (list[r], list[i]) = (list[i], list[r]);
        }
    }

    public static T Pop<T>(this ObservableCollection<T> list)
    {
        if (list.Count == 0)
        {
            return default;
        }

        T item = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return item;
    }
}
