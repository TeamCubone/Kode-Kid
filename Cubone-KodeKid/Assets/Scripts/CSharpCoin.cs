using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpCoin : MonoBehaviour
{
    [SerializeField] int coinCount = 0;
    [SerializeField] AudioClip coinPickUpSFX;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        FindObjectOfType<GameSession>().AddScore(coinCount);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
    }

}
