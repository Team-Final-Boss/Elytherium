using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    const float timeToAttack = 0.1f;

    public Collider playerArmaCollider;
    public Transform transformArma;
    public float time = timeToAttack;

    private ConfigScript configScript;



    private Vector3 leftPos = new Vector3(-0.78999263f, -0.172436416f, -0.0415452421f);
    private Vector3 downPos = new Vector3(-0.0299999993f, -0.172436416f, -1.32000005f);
    private Vector3 rightPos = new Vector3(0.785000026f, -0.172436416f, -0.0415452421f);
    private Vector3 upPos = new Vector3(-0.0299999993f, -0.172436416f, 1.38999999f);

    void ChangeArmaPos()
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
            transformArma.localPosition = leftPos;
        }
        else if (IsPressed(down))
        {
            transformArma.localPosition = downPos;
        }
        else if (IsPressed(right))
        {
            transformArma.localPosition = rightPos;
        }
        else if (IsPressed(up))
        {
            transformArma.localPosition = upPos;
        }
    }

    bool IsPressed(KeyCode key)
    {
        return Input.GetKeyDown(key) || Input.GetKey(key);
    }


    void UpdateTime()
    {
        if (playerArmaCollider.enabled == true)
        {
            time = time - Time.deltaTime;
        }

        if (time <= 0)
        {
            playerArmaCollider.enabled = false;
            time = timeToAttack;
            Debug.Log(playerArmaCollider.enabled);
            Debug.Log(time);
        }

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
        Attack();
        UpdateTime();
        ChangeArmaPos();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerArmaCollider.enabled = true;
            Debug.Log(time);
            Debug.Log(playerArmaCollider.enabled);
        }

    }
}
