using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cutsceneCamera;
    public GameObject playerCamera;

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
    
            cutsceneCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
        Debug.Log("collided with " + other.gameObject.name);
        }
    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player")
        {
           
            cutsceneCamera.SetActive(false);
            playerCamera.SetActive(true);
            
        }
    }
}
