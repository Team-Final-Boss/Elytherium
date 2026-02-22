using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class MoveSoundController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public float minSpeedToPlay = 0.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = true;
    }

    void Update()
    {
        // Cria vetor só com X e Z
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        float speed = horizontalVelocity.magnitude;

        if (speed > minSpeedToPlay)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}