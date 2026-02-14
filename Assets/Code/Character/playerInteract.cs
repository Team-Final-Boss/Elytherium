using UnityEngine;

public class playerInteract : MonoBehaviour
{

 


    public Transform transformInteract;



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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        changeInteractPos();
    }

   
}
