using UnityEngine;

public class playerInteract : MonoBehaviour
{

    const float timeToInteract = 0.1f;

    public Collider playerInteractCollider;
    public Transform transformInteract;
    public float time = timeToInteract;



    void changeInteractPos()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            transformInteract.localPosition = new Vector3(-0.78999263f,-0.172436416f,-0.0415452421f);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transformInteract.localPosition = new Vector3(-0.0299999993f,-0.172436416f,-1.32000005f);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transformInteract.localPosition = new Vector3(0.785000026f,-0.172436416f,-0.0415452421f);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            transformInteract.localPosition = new Vector3(-0.0299999993f,-0.172436416f,1.38999999f);
        }
    }
    void UpdateTime()
    {
        if (playerInteractCollider.enabled == true){
            time = time - Time.deltaTime;
        }
        
        if (time <= 0)
        {
            playerInteractCollider.enabled = false;
            time = timeToInteract;
            Debug.Log(playerInteractCollider.enabled);
            Debug.Log(time);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        UpdateTime();
        changeInteractPos();
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteractCollider.enabled = true;
            Debug.Log(time);
            
            Debug.Log(playerInteractCollider.enabled);
        }
        
    }
}
