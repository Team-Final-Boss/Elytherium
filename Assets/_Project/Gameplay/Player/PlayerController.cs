using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MoveScript moveScript;
    private PlayerAnimationController playerAnimationController;

    private InputSystem_Actions inputActions;

    private ConfigScript configScript;

    private Vector3 inputDir;
    private bool canMove = true;
    private bool isAttacking;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        moveScript = GetComponent<MoveScript>();
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
    }



    void Start()
    {
        
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();

        UpdateControlScheme(configScript.controls);
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void UpdateControlScheme(int controlType)
    {
        switch (controlType)
        {
            case 0: // SETAS
                inputActions.bindingMask =
                   InputBinding.MaskByGroup("Arrows");
                break;

            case 1: // WASD
                inputActions.bindingMask =
                    inputActions.bindingMask = InputBinding.MaskByGroup("WASD");
                break;
        }
    }

    void Update()
    {
        
        inputDir = ReadInput();

        if (inputActions.Player.Attack.WasPressedThisFrame() && !isAttacking)
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

    Vector3 ReadInput()
    {
        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 dir = new Vector3(move.x, 0f, move.y);

        if (dir.magnitude > 1f)
            dir.Normalize();

        return dir;
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
}
