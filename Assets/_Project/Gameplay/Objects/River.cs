using UnityEngine;
using System.Collections;

public class River : MonoBehaviour
{
    [Header("References")]
    public Transform river;
    public GameObject teleporter;

    [Header("River Settings")]
    public Vector3 position2;
    [SerializeField] private float fillDuration = 2f;
    [SerializeField] private int rocksRequired = 5;

    private SaveScript saveScript;
    private AudioSource audioSource;

    private int rocksReceived = 0;
    private Vector3 startPosition;
    private bool isFilling = false;
    private bool isFilled = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("[River] Nenhum AudioSource encontrado no objeto.");
        }
    }

    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
            Debug.LogError("GameController não encontrado na cena!");
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();
        startPosition = river.localPosition;

        if (!saveScript.river)
        {
            river.localPosition = position2;
            teleporter.SetActive(true);
            isFilled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isFilled) return;

        if (other.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
            rocksReceived++;

          
            if (audioSource != null)
            {
                audioSource.Play();
            }

            if (rocksReceived >= rocksRequired && !isFilling)
            {
                StartCoroutine(FillRiver());
            }
        }
    }

    private IEnumerator FillRiver()
    {
        isFilling = true;

        float time = 0f;

        while (time < fillDuration)
        {
            float t = time / fillDuration;
            t = t * t * (3f - 2f * t); // SmoothStep

            river.localPosition = Vector3.Lerp(startPosition, position2, t);

            time += Time.deltaTime;
            yield return null;
        }

        river.localPosition = position2;

        teleporter.SetActive(true);
        saveScript.river = false;

        isFilled = true;
        isFilling = false;
    }
}