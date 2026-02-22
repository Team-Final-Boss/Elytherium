using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.5f;

    private Coroutine currentFade;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        SetAlpha(1);
    }

    private void Start()
    {
        StartFadeIn();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartFadeIn();
    }

    void StartFadeIn()
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        SetAlpha(1);
        currentFade = StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(targetAlpha);
        currentFade = null;
    }

    void SetAlpha(float a)
    {
        Color c = fadeImage.color;
        c.a = a;
        fadeImage.color = c;
    }
}