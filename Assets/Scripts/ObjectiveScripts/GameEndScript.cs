using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    private PlayerManager playerManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerManager = collision.gameObject.GetComponent<PlayerManager>();
        if (playerManager)
        {
            playerManager.Kill();
        }
    }
}
