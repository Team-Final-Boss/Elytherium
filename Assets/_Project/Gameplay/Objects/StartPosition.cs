using UnityEngine;

public class StartPosition : MonoBehaviour
{

    private SaveScript saveScript;

    public int missionNecessary = 4;

    public GameObject bridge;

    public Transform other;

    private bool playerTeleported = false;

    public Vector3 positionStart = new Vector3(0, 0, 0);
    public Vector3 positionStart2 = new Vector3(0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(saveScript.missionComplete == missionNecessary && !playerTeleported) 
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            if(!saveScript.river){
            other.position = new Vector3(111.34f, 20.5f, 79.48f);}
            bridge.SetActive(false);
            player.position = positionStart;
            playerTeleported = true;
        }
        else if(saveScript.missionComplete > missionNecessary && !playerTeleported)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            if(!saveScript.river){
            other.position = new Vector3(111.34f, 20.5f, 79.48f);}
            bridge.SetActive(false);
            player.position = positionStart2;
            playerTeleported = true;
        }
        else if(saveScript.missionComplete == 3)
        {
            playerTeleported = true;
        }
    }
}
