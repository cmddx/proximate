using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bump : MonoBehaviour
{
    [SerializeField] Color bumpColor;
    public void ShowBump()
    {
        StartCoroutine(FadeIn(bumpColor));
        StartCoroutine(FadeOut(bumpColor));
    }

    IEnumerator FadeIn(Color bumpColor)
    {
        int beginningAlpha = 0;
        int endingAlpha = 1;

        Color startingColor = new Color(bumpColor.r, bumpColor.g,
            bumpColor.b, beginningAlpha);
        Color endingColor = new Color(bumpColor.r, bumpColor.g,
            bumpColor.b, endingAlpha);

        float t = 0.0f;
        while (t <= 0.5f)
        {
            t += Time.deltaTime;
            GetComponent<Image>().color = Color.Lerp(startingColor,
                endingColor, t * 2);
            yield return null;
        }
    }

    IEnumerator FadeOut(Color bumpColor)
    {
        yield return new WaitForSeconds(0.5f);

        int beginningAlpha = 1;
        int endingAlpha = 0;

        Color startingColor = new Color(bumpColor.r, bumpColor.g,
            bumpColor.b, beginningAlpha);
        Color endingColor = new Color(bumpColor.r, bumpColor.g,
            bumpColor.b, endingAlpha);

        float t = 0.0f;
        while (t <= 0.5f)
        {
            t += Time.deltaTime;
            GetComponent<Image>().color = Color.Lerp(startingColor,
                endingColor, t * 2);
            yield return null;
        }
    }
}
