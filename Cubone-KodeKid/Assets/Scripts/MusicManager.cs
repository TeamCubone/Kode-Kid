using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create a music when its starting the game
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioSource audioSourceIntro;
    public AudioSource audioSourceLoop;
    private bool startedLoop;

    // this will trigger app to start the muix
    private void Start()
    {
        startedLoop = false;
    }

    // check every frame to see if its playiing and if its not then play again
    void FixedUpdate()
    {
        if (!audioSourceIntro.isPlaying && !startedLoop)
        {
            audioSourceLoop.Play();
            startedLoop = true;
        }
    }
}
