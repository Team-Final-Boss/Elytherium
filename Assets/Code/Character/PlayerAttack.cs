using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    const float timeToAttack = 0.1f;

    public Collider playerArmaCollider;
    public Transform transformArma;
    public float time = timeToAttack;



    void changeArmaPos()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            transformArma.localPosition = new Vector3(-0.78999263f,-0.172436416f,-0.0415452421f);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transformArma.localPosition = new Vector3(-0.0299999993f,-0.172436416f,-1.32000005f);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transformArma.localPosition = new Vector3(0.785000026f,-0.172436416f,-0.0415452421f);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            transformArma.localPosition = new Vector3(-0.0299999993f,-0.172436416f,1.38999999f);
        }
    }
    void UpdateTime()
    {
        if (playerArmaCollider.enabled == true){
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        UpdateTime();
        changeArmaPos();
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
