using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpCoin : MonoBehaviour
{
    /// <summary>
    /// Serialize Field that will count coin when user pick up and the audio that comes iwth it
    /// </summary>
    [SerializeField] int coinCount = 0;
    [SerializeField] AudioClip coinPickUpSFX;

    /// <summary>
    /// On collision it will trigger sound 
    /// </summary>
    /// <param name="collison">collision of character</param>
    private void OnTriggerEnter2D(Collider2D collison)
    {
        FindObjectOfType<GameSession>().AddScore(coinCount);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
    }

}
