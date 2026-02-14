using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    const float timeToAttack = 0.1f;

    public Collider playerArmaCollider;
    public Transform transformArma;
    public float time = timeToAttack;



    void changeArmaPos()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transformArma.localPosition = new Vector3(-0.78999263f,-0.172436416f,-0.0415452421f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transformArma.localPosition = new Vector3(-0.0299999993f,-0.172436416f,-1.32000005f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transformArma.localPosition = new Vector3(0.785000026f,-0.172436416f,-0.0415452421f);
        }

        if (Input.GetKeyDown(KeyCode.W))
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
