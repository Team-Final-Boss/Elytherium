using UnityEngine;

/// <summary>
///   PlayerAnimationController manages the player's animations based on movement and attack states. It interacts with the Animator component to trigger appropriate animations and with the Attack component to enable or disable the attack hitbox during attack animations. This script should be attached to a child GameObject of the player that has an Animator component, and it should have an Attack component as a child for handling attack hitboxes.
/// </summary>
public class PlayerAnimationController : MonoBehaviour {
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private Attack attack;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponentInParent<PlayerController>();
        attack = GetComponentInChildren<Attack>();

        if (attack == null)
        {
            Debug.LogError("Attack component not found in children.");
        }
    }

    #region Control Methods

    /// <summary>
    ///     SetGrounded is called by the MoveScript to update the grounded state of the player, which can be used to transition between grounded and airborne animations.
    /// </summary>
    /// <param name="grounded">
    ///     Indicates whether the player is currently grounded. This can be used to transition between grounded and airborne animations.
    /// </param>
    public void SetGrounded(bool grounded)
    {
        animator.SetBool("isGrounded", grounded);
    }

    #region Movement Methods
    
    /// <summary>
    ///     SetMovement is called by the PlayerController to update the movement parameters of the animator based on player input. It also handles sprite flipping for left and right movement.
    /// </summary>
    /// <param name="inputDir">
    ///     The input direction vector from the PlayerController, which is used to set the movement parameters in the animator and to determine sprite flipping for left and right movement.
    /// </param>
    public void SetMovement(Vector3 inputDir)
    {
        if (inputDir.x != 0) spriteRenderer.flipX = inputDir.x < 0;
        animator.SetFloat("moveX", inputDir.x);
        animator.SetFloat("moveZ", inputDir.z);
        animator.SetBool("isWalking", inputDir.magnitude > 0.1f);
    }

    /// <summary>
    ///     NOT YET IMPLEMENTED - TriggerRun is intended to be called when the player initiates a run action. It should trigger the run animation, which can be implemented in the future to provide a faster movement option for the player.
    /// </summary>
    public void TriggerRun()
    {
        animator.SetTrigger("run");
    }

    #endregion

    #region Attack Methods

    /// <summary>
    ///     TriggerAttack is called by the PlayerController when the player initiates an attack. It triggers the attack animation and should be synchronized with the enabling and disabling of the attack hitbox through the EnableHitbox and DisableHitbox methods.
    /// </summary>
    public void TriggerAttack()
    {
        animator.SetTrigger("attack");
    }

    /// <summary>
    ///     EnableHitbox is called at the appropriate time during the attack animation to enable the attack hitbox, allowing it to detect collisions and apply damage.
    /// </summary>
    public void EnableHitbox()
    {
        attack.EnableHitbox();
    }

    /// <summary>
    ///     DisableHitbox is called at the appropriate time during the attack animation to disable the attack hitbox, preventing it from detecting collisions and applying damage when the attack is not active.
    /// </summary>
    public void DisableHitbox()
    {
        attack.DisableHitbox();
    }

    /// <summary>
    ///   OnAttackFinished is called at the end of the attack animation to reset the attack trigger and re-enable player movement. This ensures that the player can move again after the attack animation has completed.
    /// </summary>
    public void OnAttackFinished()
    {
        animator.ResetTrigger("attack"); // must reset trigger to prevent animation from looping between in attack state and idle/walk state
        playerController.EnableMovement();
    }

    #endregion

    #region Dash Methods

    /// <summary>
    ///     NOT YET IMPLEMENTED - TriggerDash is intended to be called when the player initiates a dash action. It should trigger the dash animation, which can be implemented in the future to provide a quick burst of movement for the player.
    /// </summary>
    public void TriggerDash()
    {
        animator.SetTrigger("dash");
    }

    #endregion


    #endregion
    
}