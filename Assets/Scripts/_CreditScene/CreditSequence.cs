using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class CreditSequence : MonoBehaviour
{
    [SerializeField] CanvasGroup splashCG;
    [SerializeField] CanvasGroup creditsCG;
    [SerializeField] FMODUnity.EventReference soundToPlay;
    [SerializeField] float soundToPlayDelay;

    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundPlay());
        StartCoroutine(Credits());
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 5 && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SoundPlay()
    {
        yield return new WaitForSeconds(soundToPlayDelay);

        RuntimeManager.PlayOneShot(soundToPlay, Vector3.zero);
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(5);

        float elapsedTime = 0;

        while (elapsedTime < 1)
        {
            float newAlpha = Mathf.Lerp(0, 1,
            Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / 1));

            splashCG.alpha = 1 - newAlpha;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0;

        while (elapsedTime < 1)
        {
            float newAlpha = Mathf.Lerp(0, 1,
            Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / 1));

            creditsCG.alpha = newAlpha;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
