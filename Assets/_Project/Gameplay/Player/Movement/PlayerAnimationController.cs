using System;
using UnityEngine;

/// <summary>
///   PlayerAnimationController manages the player's animations based on movement and attack states. It interacts with the Animator component to trigger appropriate animations and with the Attack component to enable or disable the attack hitbox during attack animations. This script should be attached to a child GameObject of the player that has an Animator component, and it should have an Attack component as a child for handling attack hitboxes.
/// </summary>
public class PlayerAnimationController : MonoBehaviour {

    public event Action OnAttackAnimationCompleted;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Attack attack;
    private Vector2 lastFacingDirection = new Vector2(0f, -1f);

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attack = GetComponentInChildren<Attack>(true);

        if (attack == null)
        {
            Debug.LogError("[PlayerAnimationController] Attack component not found in children. Verifique a hierarquia!", this);
        }
    }

    #region Control Methods

    #region Movement Methods

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
    
    /// <summary>
    ///     SetMovement is called by the PlayerController to update the movement parameters of the animator based on player input. It also handles sprite flipping for left and right movement.
    /// </summary>
    /// <param name="inputDir">
    ///     The input direction vector from the PlayerController, which is used to set the movement parameters in the animator and to determine sprite flipping for left and right movement.
    /// </param>
    public void SetMovement(Vector3 inputDir)
    {
        float magnitude = inputDir.magnitude;
        bool walking = magnitude > 0.01f;

        if (inputDir.x != 0) spriteRenderer.flipX = inputDir.x < 0;
        
        animator.SetBool("isWalking", walking);

        if (walking)
        {
            lastFacingDirection.x = inputDir.x;
            lastFacingDirection.y = inputDir.z;

            /* the animator parameters are named moveX and moveZ to match the input direction's x and z components, which represent horizontal and vertical movement respectively. This allows the animator to use these parameters to determine the appropriate animation based on the player's movement direction.
            
            @oEnzoRibas - 2026.02.18 - 
            Note:
            they should be updated only when the player is walking to ensure that the last facing direction is maintained when the player stops moving, allowing for idle animations to face the correct direction. 

            This fixes the animation bug where the player would snap back to the first animation in the blendtree when stopping movement.
            */
            animator.SetFloat("moveX", inputDir.x);
            animator.SetFloat("moveZ", inputDir.z);
        }

        animator.SetFloat("lastMoveX", lastFacingDirection.x);
        animator.SetFloat("lastMoveZ", lastFacingDirection.y);

    }

    /// <summary>
    ///     NOT YET IMPLEMENTED - TriggerRun is intended to be called when the player initiates a run action. It should trigger the run animation, which can be implemented in the future to provide a faster movement option for the player.
    /// </summary>
    public void TriggerRun()
    {
        animator.SetTrigger("run");
    }

    /// <summary>
    ///     NOT YET IMPLEMENTED - TriggerDash is intended to be called when the player initiates a dash action. It should trigger the dash animation, which can be implemented in the future to provide a quick burst of movement for the player.
    /// </summary>
    public void TriggerDash()
    {
        animator.SetTrigger("dash");
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
        // Esse log vai dedurar EXATAMENTE quando a arma for ligada.
        Debug.LogWarning($"[🚨🚨🚨🚨 DETETIVE] Alguém chamou EnableHitbox! Tempo: {Time.time}"); 
        
        attack.UpdateHitboxPosition(lastFacingDirection);
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
        attack.DisableHitbox();
        OnAttackAnimationCompleted?.Invoke();
    }

    #endregion

    #endregion
    
}