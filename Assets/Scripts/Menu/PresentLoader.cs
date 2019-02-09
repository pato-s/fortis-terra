using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PresentLoader : MonoBehaviour
{
    public GameObject Dot;
    public GameObject PatosLogo;
    public TMP_Text PatosName;
    public TMP_Text PatosPresent;
    public TMP_Text FortisTerraName;
    public TMP_Text Disclaimer;
    public TMP_Text FortisTerraFooter;
    public float LoadPause = 1f;
    public GameObject StampSound;
    public GameObject Border;
    public GameObject Soon;

    void Awake()
    {
        Dot.SetActive(false);
        StampSound.SetActive(false);
        PatosLogo.SetActive(false);
        PatosName.gameObject.SetActive(false);
        PatosPresent.gameObject.SetActive(false);
        FortisTerraName.gameObject.SetActive(false);
        Disclaimer.gameObject.SetActive(false);
        FortisTerraFooter.gameObject.SetActive(false);
        Border.SetActive(false);
        Soon.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(LoadPause);
        Dot.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Dot.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Dot.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Dot.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Dot.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Dot.SetActive(false);
        yield return new WaitForSeconds(1.3f);
        PatosLogo.SetActive(true);
        PlayPatosName();
        yield return true;
    }

    private void PlayPatosName()
    {
        UnityEvent EndEvent = new UnityEvent();
        EndEvent.AddListener(PlayPatosPresent);
        PatosName.gameObject.AddComponent<TextWriter>();
        TextWriter writer = PatosName.GetComponent<TextWriter>();
        writer.LoadPause = LoadPause * 1.5f;
        writer.OnEnd = EndEvent;
        PatosName.gameObject.SetActive(true);
    }

    private void PlayPatosPresent()
    {
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        PatosName.fontStyle = TMPro.FontStyles.Underline;
        PatosPresent.gameObject.AddComponent<TextWriter>();
        UnityEvent FortisTerraNameEvent = new UnityEvent();
        FortisTerraNameEvent.AddListener(PlayFortisTerraName);
        TextWriter writer = PatosPresent.GetComponent<TextWriter>();
        writer.LoadPause = LoadPause * 1.3f;
        writer.OnEnd = FortisTerraNameEvent;
        PatosPresent.gameObject.SetActive(true);
    }

    private void PlayFortisTerraName()
    {
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        PatosPresent.text += ":";
        FortisTerraName.gameObject.AddComponent<TextWriter>();
        UnityEvent PlayDisclaimerEvent = new UnityEvent();
        PlayDisclaimerEvent.AddListener(PlayDisclaimer);
        TextWriter writer = FortisTerraName.GetComponent<TextWriter>();
        writer.LoadPause = LoadPause * 1.2f;
        writer.letterPause *= 2.7f;
        writer.OnEnd = PlayDisclaimerEvent;
        FortisTerraName.gameObject.SetActive(true);
    }

    private void PlayDisclaimer()
    {
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        FortisTerraName.fontStyle = TMPro.FontStyles.Underline;
        Disclaimer.gameObject.AddComponent<TextWriter>();
        TextWriter writer = Disclaimer.GetComponent<TextWriter>();
        UnityEvent FortisTerraFooterEndEvent = new UnityEvent();
        FortisTerraFooterEndEvent.AddListener(PlayFortisTerraFooter);
        writer.LoadPause = 2.1f;
        writer.letterPause *= 0.5f;
        writer.OnEnd = FortisTerraFooterEndEvent;
        Disclaimer.gameObject.SetActive(true);
    }

    private void PlayFortisTerraFooter()
    {
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        Disclaimer.text += ".";
        FortisTerraFooter.gameObject.AddComponent<TextWriter>();
        TextWriter writer = FortisTerraFooter.GetComponent<TextWriter>();
        UnityEvent FortisTerraFooterEndEvent = new UnityEvent();
        FortisTerraFooterEndEvent.AddListener(PlayFortisTerraFooterEnd);
        writer.LoadPause *= 0.6f;
        writer.letterPause *= 0.8f;
        writer.OnEnd = FortisTerraFooterEndEvent;
        FortisTerraFooter.gameObject.SetActive(true);
    }

    private void PlayFortisTerraFooterEnd()
    {
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        FortisTerraFooter.text += ".";
        StartCoroutine(ShowBorder());
    }

    IEnumerator ShowBorder()
    {
        yield return new WaitForSeconds(1f);
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        Border.SetActive(true);
        StartCoroutine(ShowSoon());
    }

    IEnumerator ShowSoon()
    {
        yield return new WaitForSeconds(6f);
        Dot.SetActive(false);
        StampSound.SetActive(false);
        PatosLogo.SetActive(false);
        PatosName.gameObject.SetActive(false);
        PatosPresent.gameObject.SetActive(false);
        FortisTerraName.gameObject.SetActive(false);
        Disclaimer.gameObject.SetActive(false);
        FortisTerraFooter.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        StampSound.SetActive(false);
        StampSound.SetActive(true);
        Soon.SetActive(true);
    }
}
