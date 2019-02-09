using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextWriter : MonoBehaviour
{
    public float LoadPause = 1f;
    public float letterPause = 0.1f;
    public UnityEvent OnEnd;

    string message;
    TMP_Text textComp;

    void Start()
    {
        textComp = GetComponent<TMP_Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(LoadPause);
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            SoundManager.instance.TypeRandomizeSfx();
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        if (OnEnd != null) OnEnd.Invoke();
    }
}
