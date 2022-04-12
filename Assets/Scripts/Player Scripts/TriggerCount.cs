using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
    private List<GameObject> colliders = new List<GameObject>();

    public int NumberOfObjects => colliders.Count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!colliders.Contains(collision.gameObject)) colliders.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (colliders.Contains(collision.gameObject)) colliders.Remove(collision.gameObject);
    }
}
