using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

    public GameObject Present;

    void Awake()
    {
        Present.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(2f);
        Present.SetActive(true);
    }
}
