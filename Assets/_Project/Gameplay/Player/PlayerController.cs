using UnityEngine;


/// <summary>
///     PlayerController is responsible for handling player input, controlling movement, and managing attack states. It interacts with the MoveScript for movement mechanics and the PlayerAnimationController for visual feedback. The controller ensures that player actions are synchronized with animations and that movement is appropriately enabled or disabled during attacks.
/// </summary>
/// <remarks>
///     This script should be attached to the player GameObject, which must also have a MoveScript component. The PlayerAnimationController should be a child of the player GameObject and contain an Attack component for handling attack hitboxes.
/// </remarks>
/// 
/// 
[RequireComponent(typeof(MoveScript))]
public class PlayerController : MonoBehaviour
{
    private MoveScript moveScript;
    private PlayerAnimationController playerAnimationController;

    private Vector3 inputDir;
    private bool canMove = true;
    private bool isAttacking;

    private bool isAttackUnlocked = false;


    #region Unity Methods
    /// <summary>
    ///     Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        moveScript = GetComponent<MoveScript>();
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
    }
    /// <summary>
    ///   ///     Update is called once per frame.
    /// </summary>
    void Update()
    {

        Debug.Log("<color=green>Lendo Input...</color>"); 

        inputDir = ReadInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"[DEBUG] Espaço pressionado. isAttacking: {isAttacking} | isAttackUnlocked: {isAttackUnlocked}");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking && isAttackUnlocked)
        {
            Debug.Log("[DEBUG] Passou pela trava! Disparando trigger de ataque...");
            InitiateAttack();
        }

        if (!canMove)
        {
            inputDir = Vector3.zero;
        }
        
        moveScript.SetDirection(inputDir);
        playerAnimationController.SetMovement(inputDir);

    }

    void OnEnable() {
        if (playerAnimationController != null)
        {
            playerAnimationController.OnAttackAnimationCompleted += OnAttackEnded;
        }
    }

    void OnDisable() {
        if (playerAnimationController != null)
        {
            playerAnimationController.OnAttackAnimationCompleted -= OnAttackEnded;
        }
    }


    #endregion

    #region Input Control Methods
    
    /// <summary>
    ///     Reads player input and returns a normalized direction vector.
    /// </summary>
    /// <returns>
    ///     A normalized direction vector representing player input.
    /// </returns>
    Vector3 ReadInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(moveX, 0f, moveZ);

        if (dir.sqrMagnitude > 1f) // maagnitude is expensive to compute, so we use sqrMagnitude for comparison
            dir.Normalize();

        return dir;
    }

    #region Attack Control Methods

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



    #region Movement Control Methods
    /// <summary>
    ///     Enables player movements.
    /// </summary>
    ///
    public void EnableMovement()
    {
        canMove = true;
        isAttacking = false;
    }

    /// <summary>
    ///     Disables player movements.
    /// </summary>
    public void DisableMovement()
    {
        canMove = false;
    }
    #endregion

    #endregion
}