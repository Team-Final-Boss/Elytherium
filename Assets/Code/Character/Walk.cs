using UnityEngine;


public class Walk : MonoBehaviour
{
    private ConfigScript configScript;
    
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (configScript.controls == 1)
        {
            moveZ = (Input.GetKey(KeyCode.W) ? 1 : 0) -
                    (Input.GetKey(KeyCode.S) ? 1 : 0);

            moveX = (Input.GetKey(KeyCode.D) ? 1 : 0) -
                    (Input.GetKey(KeyCode.A) ? 1 : 0);
        }
        else
        {
            moveZ = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) -
                    (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

            moveX = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) -
                    (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
        }

        Vector3 inputDir = new Vector3(moveX, 0, moveZ);

        bool condition = inputDir.magnitude > 0.1f;
        
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveZ", moveZ);
        animator.SetBool("isWalking", condition);

        
        
    }
}
