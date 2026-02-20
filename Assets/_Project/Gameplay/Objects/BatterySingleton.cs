using UnityEngine;
using UnityEngine.SceneManagement;

public class BatterySingleton : MonoBehaviour
{
    public static BatterySingleton instance;

    public int belongingScene; // build index da cena

    private Rigidbody rb;
    private MeshRenderer mesh;
    private Collider col;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool isCorrectScene = scene.buildIndex == belongingScene;

        if (rb != null)
            rb.isKinematic = !isCorrectScene;

        if (mesh != null)
            mesh.enabled = isCorrectScene;

        if (col != null)
            col.enabled = isCorrectScene;
    }
}