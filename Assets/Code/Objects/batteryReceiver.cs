using UnityEngine;

public class batteryReceiver : MonoBehaviour
{

    public bool hasBattery = false;

    public GameObject cutsceneCamera;
    public GameObject playerCamera;

    public GameObject bridge;

    public GameObject wall;

    public MoveScript moveScript;

    public float time = 3f;

    private bool cutscenePlayed = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cutscene();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            if (hasBattery == false){
            teleportBattery(other);
            cutscenePlayed = false;
            Debug.Log("battery teleported");}
        }
        Debug.Log("collided with " + other.gameObject.name);
    }

    void teleportBattery(Collider other)
    {
        hasBattery = true;
            other.gameObject.transform.position = this.transform.position;
            other.gameObject.transform.rotation = this.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
           
    }

    void cutscene()
    {
        if (cutscenePlayed == false)
        {
            time -= Time.deltaTime;
            cutsceneCamera.SetActive(true);
            playerCamera.SetActive(false);
            moveScript.enabled = false;
            
            if(time <= 0)
            {
                cutsceneCamera.SetActive(false);
                playerCamera.SetActive(true);
                moveScript.enabled = true;
                cutscenePlayed = true;
               
            }
            else if(time <= 2)
            {
                 bridge.SetActive(true);
                 wall.SetActive(false);
            }


        }

        
    }
}
