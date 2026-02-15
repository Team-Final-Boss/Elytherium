using UnityEngine;

public class playerInteract : MonoBehaviour
{

 


    public Transform transformInteract;

    private ConfigScript configScript;
        



    void changeInteractPos()
    {

        if(configScript.controls == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
            {
                transformInteract.localPosition = new Vector3(-0.78999263f,-0.172436416f,-0.0415452421f);
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                transformInteract.localPosition = new Vector3(-0.0299999993f,-0.172436416f,-1.32000005f);
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                transformInteract.localPosition = new Vector3(0.785000026f,-0.172436416f,-0.0415452421f);
            }

            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            {
                transformInteract.localPosition = new Vector3(-0.0299999993f,-0.172436416f,1.38999999f);
            }
        }
        else if(configScript.controls == 0)
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
        }}
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        changeInteractPos();
    }

   
}
