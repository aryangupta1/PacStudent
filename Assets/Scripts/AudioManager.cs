using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource normalState;

    void Start()
    {
        // Plays intro sound and then next state
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        intro.Play();

        // Wait for 8 seconds
        yield return new WaitForSeconds(8f);

        // If gameIntroAudio is still playing after 8 seconds, stop it
        if (intro.isPlaying)
            intro.Stop();

        // Play the normal state audio on loop
        normalState.loop = true;
        normalState.Play();
    }
}
