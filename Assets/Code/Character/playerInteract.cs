using UnityEngine;

public class playerInteract : MonoBehaviour
{




    public Transform transformInteract;

    private ConfigScript configScript;




    private Vector3 leftPos = new Vector3(-0.78999263f, -0.172436416f, -0.0415452421f);
    private Vector3 downPos = new Vector3(-0.0299999993f, -0.172436416f, -1.32000005f);
    private Vector3 rightPos = new Vector3(0.785000026f, -0.172436416f, -0.0415452421f);
    private Vector3 upPos = new Vector3(-0.0299999993f, -0.172436416f, 1.38999999f);

    void changeInteractPos()
    {
        if (configScript.controls == 1)
            HandleInput(KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.W);
        else
            HandleInput(KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.UpArrow);
    }

    void HandleInput(KeyCode left, KeyCode down, KeyCode right, KeyCode up)
    {
        if (IsPressed(left) && !IsPressed(down) && !IsPressed(up))
        {
            transformInteract.localPosition = leftPos;
        }
        else if (IsPressed(down))
        {
            transformInteract.localPosition = downPos;
        }
        else if (IsPressed(right))
        {
            transformInteract.localPosition = rightPos;
        }
        else if (IsPressed(up))
        {
            transformInteract.localPosition = upPos;
        }
    }

    bool IsPressed(KeyCode key)
    {
        return Input.GetKeyDown(key) || Input.GetKey(key);
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
