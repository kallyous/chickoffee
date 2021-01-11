using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource track;

    void Start()
    {
        track = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        track.Play();
    }

    public void Stop()
    {
        track.Stop();
    }
}
