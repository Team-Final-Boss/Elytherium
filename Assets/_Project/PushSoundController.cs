using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PushSoundController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public float minSpeedToPlay = 0.1f;
    public float startDelay = 5f; // tempo antes de começar a detectar

    private bool isBeingTouched = false;
    private bool hasPlayedThisPush = false;
    private bool canDetect = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = false;
    }

    void Start()
    {
        StartCoroutine(EnableDetectionAfterDelay());
    }

    IEnumerator EnableDetectionAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        canDetect = true;
    }

    void Update()
    {
        if (!canDetect) return;

        float speed = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude;

        if (isBeingTouched && speed > minSpeedToPlay)
        {
            if (!hasPlayedThisPush)
            {
                audioSource.Play();
                hasPlayedThisPush = true;
            }
        }

        if (speed <= minSpeedToPlay)
        {
            hasPlayedThisPush = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!canDetect) return;
        isBeingTouched = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (!canDetect) return;
        isBeingTouched = false;
    }
}