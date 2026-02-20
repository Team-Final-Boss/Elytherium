using UnityEngine;

public class batteryReceiver2 : MonoBehaviour
{

    public bool hasBattery = false;


    
   

    public float time = 3f;

    public interactScript interact;

    private SaveScript saveScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            if (hasBattery == false){
            ChargedBattery batteryScript = other.gameObject.GetComponent<ChargedBattery>();
            if(batteryScript.isCharged == true){
            teleportBattery(other);}
            Debug.Log("battery teleported");}
        }
        Debug.Log("collided with " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            hasBattery = false;
            ChargedBattery batteryScript = other.gameObject.GetComponent<ChargedBattery>();
            if (batteryScript != null)
            {
                batteryScript.isOnPosition = false;
            }
        }
    }

    void teleportBattery(Collider other)
{
    hasBattery = true;

    Rigidbody rb = other.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    other.transform.position = transform.position;
    other.transform.rotation = transform.rotation;

    ChargedBattery batteryScript = other.GetComponent<ChargedBattery>();
    if (batteryScript != null)
    {
        batteryScript.enabled = false;
        if(saveScript.missionComplete < 8)
            {
                saveScript.missionComplete = 7;
            }
        
    }
}

   
}
