using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transition : MonoBehaviour
{
    public Image blackscreen;

    public GameObject destructable;
    public GameObject rocks;

    public GameObject otherGameObject;



    public float fadeDuration = 1f;

    public void Blackscreen()
    {
        StartCoroutine(TransitionRoutine());
    }

    public void StartTeleport(Vector3 positionTeleport)
    {
        StartCoroutine(Teleport(positionTeleport));
    }

    public void StartTeleportOther(Vector3 positionTeleport)
    {
        StartCoroutine(TeleportOther(positionTeleport));
    }

    IEnumerator Teleport(Vector3 positionTeleport)
    {
        // Fade In (tela preta)
        yield return StartCoroutine(Fade(0f, 1f));

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = positionTeleport;

        // Fade Out
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator TeleportOther(Vector3 positionTeleport)
    {
        // Fade In (tela preta)
        yield return StartCoroutine(Fade(0f, 1f));

        Transform other = otherGameObject.transform;
        other.position = positionTeleport;

        // Fade Out
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator TransitionRoutine()
    {
        // 🔹 FADE IN (0 → 1)
        yield return StartCoroutine(Fade(0f, 1f));

        // 🔹 Ação no meio (tela preta)
        if (destructable != null)
            Destroy(destructable);

        if (rocks != null)
            rocks.SetActive(true);

        // 🔹 FADE OUT (1 → 0)
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float start, float end)
    {
        float elapsed = 0f;
        Color color = blackscreen.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            color.a = alpha;
            blackscreen.color = color;
            yield return null;
        }

        color.a = end;
        blackscreen.color = color;
    }
}
