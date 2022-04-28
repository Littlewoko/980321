using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private bool DisableOnKill;
    public UnityEvent OnHit;
    private PlayerManager playerManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerManager = collision.gameObject.GetComponent<PlayerManager>();
        if (playerManager)
        {
            playerManager.Kill();
            OnHit?.Invoke();
            if (DisableOnKill) gameObject.SetActive(false);
        }
    }
}
