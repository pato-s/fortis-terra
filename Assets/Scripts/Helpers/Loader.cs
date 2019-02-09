using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject soundManager;

    void Awake()
    {
        if (soundManager && SoundManager.instance == null)
            Instantiate(soundManager);
    }
}
