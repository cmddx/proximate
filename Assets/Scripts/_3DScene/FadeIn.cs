using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] float period;
    [SerializeField] float delay;
    [SerializeField] float initialAlpha;
    [SerializeField] float finalAlpha;



    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = initialAlpha;

        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0;

        while (elapsedTime < period)
        {
            float newAlpha = Mathf.Lerp(initialAlpha, finalAlpha,
            Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / period));

            canvasGroup.alpha = newAlpha;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
