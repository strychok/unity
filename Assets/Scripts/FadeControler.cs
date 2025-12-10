using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    public CanvasGroup canvasGroup;
    public CanvasGroup canvasGroupText;
    public float fadeDuration = 2f;

    void Awake()
    {
        Instance = this;
    }

    public IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            canvasGroupText.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            canvasGroupText.alpha = Mathf.Lerp(1, 0, t / 0.1f);
            yield return null;
        }
    }
}