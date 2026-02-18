using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MoveScript moveScript;
    private PlayerAnimationController playerAnimationController;

    private Vector3 inputDir;

    private bool canMove = true;

    private bool isAttacking;
    void Awake()
    {
        moveScript = GetComponent<MoveScript>();
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
    }

    void Update()
    {
        inputDir = ReadInput();


        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            isAttacking = true;
            canMove = false;
            playerAnimationController.TriggerAttack();
        }

        

        if (!canMove)
        {
            inputDir = Vector3.zero;
        }
        
        moveScript.SetDirection(inputDir);
        playerAnimationController.SetMovement(inputDir);

    }

    public void EnableMovement()
    {
        canMove = true;
        isAttacking = false;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    Vector3 ReadInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(moveX, 0f, moveZ);

        if (dir.magnitude > 1f)
            dir.Normalize();

        return dir;
    }

    public void OnAttackFinished()
    {
        canMove = true;
        isAttacking = false;
}
}