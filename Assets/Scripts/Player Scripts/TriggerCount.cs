using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCount : MonoBehaviour
{
    private List<GameObject> colliders = new List<GameObject>();

    [SerializeField] private UnityEvent onFirstEnterTrigger;
    [SerializeField] private UnityEvent onLastExitTrigger;
    private Vector2 posVector;

    public int NumberOfObjects => colliders.Count;

    public Vector2? GetDirectionToColliders(Transform tr)
    {
        if (colliders.Count == 0) return null;

        posVector = new Vector2(0f, 0f);

        for (int i = 0; i < colliders.Count; i++)
        {
            posVector.x += (colliders[i].transform.position.x - tr.position.x);
            posVector.y += (colliders[i].transform.position.y - tr.position.y);
        }

        posVector.Normalize();

        return posVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!colliders.Contains(collision.gameObject))
        {
            if (colliders.Count == 0)
            {
                onFirstEnterTrigger.Invoke();
            }
            colliders.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (colliders.Contains(collision.gameObject))
        {
            colliders.Remove(collision.gameObject);
            if (colliders.Count == 0)
            {
                onLastExitTrigger.Invoke();
            }
        }
            
    }
}
