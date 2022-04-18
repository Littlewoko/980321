using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCount : MonoBehaviour
{
    private List<GameObject> colliders = new List<GameObject>();

    [SerializeField] private UnityEvent onFirstEnterTrigger;
    [SerializeField] private UnityEvent onLastExitTrigger;

    public int NumberOfObjects => colliders.Count;

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
