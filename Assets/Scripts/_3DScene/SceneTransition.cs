using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] CanvasGroup displayCG;

    public void ChangeScene()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < 2f)
        {
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / 2);

            displayCG.alpha = newAlpha;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("HoleEndingScene", LoadSceneMode.Single);
    }
}
