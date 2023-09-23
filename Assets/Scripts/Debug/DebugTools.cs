using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DebugTools 
{
    
    public static void DrawSquare(Vector3 center, Vector2 size, Color color, float duration)
    {
        Vector3 halfSize = size * 0.5f;
        Debug.DrawLine(center + new Vector3(-halfSize.x, halfSize.y, 0), center + new Vector3(halfSize.x, halfSize.y, 0), color, duration);
        Debug.DrawLine(center + new Vector3(halfSize.x, halfSize.y, 0), center + new Vector3(halfSize.x, -halfSize.y, 0), color, duration);
        Debug.DrawLine(center + new Vector3(halfSize.x, -halfSize.y, 0), center + new Vector3(-halfSize.x, -halfSize.y, 0), color, duration);
        Debug.DrawLine(center + new Vector3(-halfSize.x, -halfSize.y, 0), center + new Vector3(-halfSize.x, halfSize.y, 0), color, duration);
    }

    public static void PrintList<T>(List<T> list)
    {
        if (list.Count > 0)
        {
            foreach (T item in list)
            {
                Debug.Log(item);
            }
        }
        else
            Debug.Log("Nothing In List");
    }

    public static void PrintDictionary<T, U>(Dictionary<T, U> dictionary)
    {
        foreach (KeyValuePair<T, U> kv in dictionary)
        {
            Debug.Log($"{kv.Key} {kv.Value}"); // Notice it's kv.Value, not kv.value
        }
    }

    
}
