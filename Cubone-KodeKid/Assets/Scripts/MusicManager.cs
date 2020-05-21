using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioSource audioSourceIntro;
    public AudioSource audioSourceLoop;
    private bool startedLoop;

    private void Start()
    {
        startedLoop = false;
    }

    void FixedUpdate()
    {
        if (!audioSourceIntro.isPlaying && !startedLoop)
        {
            audioSourceLoop.Play();
            Debug.Log("Done playing");
            startedLoop = true;
        }
    }
}
