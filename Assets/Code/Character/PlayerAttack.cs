using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    const float timeToAttack = 0.1f;

    public Collider playerArmaCollider;
    public Transform transformArma;
    public float time = timeToAttack;

    private ConfigScript configScript;
        



    void changeArmaPos()
    {
    
    if(configScript.controls == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
            {
                transformArma.localPosition = new Vector3(-0.7f,0f,0f);
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                transformArma.localPosition = new Vector3(0f,0f,0f);
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                transformArma.localPosition = new Vector3(0.7f,0f,0f);
            }

            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            {
                transformArma.localPosition = new Vector3(0f,0f,0f);
            }
        }
        else if(configScript.controls == 0)
            {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            transformArma.localPosition = new Vector3(-0.7f,0f,0f);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transformArma.localPosition = new Vector3(0f,0f,0f);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transformArma.localPosition = new Vector3(0.7f,0f,0f);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            transformArma.localPosition = new Vector3(0f,0f,0f);
        }}
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
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();
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
