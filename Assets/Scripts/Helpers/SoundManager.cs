using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource EfxSource;
    public AudioSource MusicSource;
    public AudioClip[] TypeSounds;
    public static SoundManager instance = null;

    public float lowPitchRange = 0.90f;
    public float highPitchRange = 1.20f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        EfxSource.clip = clip;
        EfxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        EfxSource.pitch = randomPitch;
        EfxSource.clip = clips[randomIndex];
        EfxSource.Play();
    }

    public void TypeRandomizeSfx()
    {
        if (TypeSounds.Length > 0)
            RandomizeSfx(TypeSounds);
    }
}
