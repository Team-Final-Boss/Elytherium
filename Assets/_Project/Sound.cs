using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    public int maxSceneID = 1;

    public int minSceneID = 0;

   // private ConfigScript configScript;
   // private AudioSource audioSource;

    // private float volume;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
       // audioSource = GetComponent<AudioSource>(); // pega o áudio do objeto
    }

    void Start()
    {

       /* GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        if(gm != null){
        configScript = gm.GetComponent<ConfigScript>();} */
    }

    void Update()
    {
   /*     if(configScript != null){
        volume = configScript.volume / 100f;

        audioSource.volume = volume;} */

        int currentSceneID = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneID > maxSceneID || currentSceneID < minSceneID)
        {
            Destroy(gameObject); 
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
        }
    }
}