using UnityEngine;

public class batteryReceiver1 : MonoBehaviour
{

    public bool hasBattery = false;


    
   

    public float time = 3f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            teleportBattery(other);
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
        other.gameObject.transform.position = this.transform.position;
        other.gameObject.transform.rotation = this.transform.rotation;
        ChargedBattery batteryScript = other.gameObject.GetComponent<ChargedBattery>();
        if (batteryScript != null)
        {
            batteryScript.isOnPosition = true;
        }


            
           
    }

   
}
