using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// PlayerController handles player input, movement and attack logic.
/// Uses Unity's New Input System and integrates with animation events.
/// </summary>
[RequireComponent(typeof(MoveScript))]
public class PlayerController : MonoBehaviour
{
    private MoveScript moveScript;
    private PlayerAnimationController playerAnimationController;

    private InputSystem_Actions inputActions;
    private ConfigScript configScript;

    private Vector3 inputDir;
    private bool canMove = true;
    private bool isAttacking;
    private bool isAttackUnlocked = true; // pode começar true ou controlar via outro script

    #region Unity Methods

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

        ApplyControlScheme(configScript.controls);
    }

    void OnEnable()
    {
        inputActions.Enable();

        if (playerAnimationController != null)
            playerAnimationController.OnAttackAnimationCompleted += OnAttackEnded;
    }

    void OnDisable()
    {
        inputActions.Disable();

        if (playerAnimationController != null)
            playerAnimationController.OnAttackAnimationCompleted -= OnAttackEnded;
    }

    void Update()
    {
        inputDir = ReadInput();

        if (inputActions.Player.Attack.WasPressedThisFrame() 
            && !isAttacking 
            && isAttackUnlocked)
        {
            InitiateAttack();
        }

        if (!canMove)
            inputDir = Vector3.zero;

        moveScript.SetDirection(inputDir);
        playerAnimationController.SetMovement(inputDir);
    }

    #endregion

    #region Control Scheme

    void ApplyControlScheme(int controlType)
    {
        inputActions.Player.Disable();

        switch (controlType)
        {
            case 0:
                inputActions.bindingMask =
                    InputBinding.MaskByGroup("Arrows");
                break;

            case 1:
                inputActions.bindingMask =
                    InputBinding.MaskByGroup("WASD");
                break;
        }

        inputActions.Player.Enable();
    }

    #endregion

    #region Input

    Vector3 ReadInput()
    {
        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 dir = new Vector3(move.x, 0f, move.y);

        if (dir.sqrMagnitude > 1f)
            dir.Normalize();

        return dir;
    }

    #endregion

    #region Attack

    private void InitiateAttack()
    {
        isAttacking = true;
        canMove = false;
        playerAnimationController.TriggerAttack();
    }

    private void OnAttackEnded()
    {
        EnableMovement();
    }

    public void SetAttackUnlocked(bool state)
    {
        isAttackUnlocked = state;
    }

    #endregion

    #region Movement

    public void EnableMovement()
    {
        canMove = true;
        isAttacking = false;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    #endregion
}
