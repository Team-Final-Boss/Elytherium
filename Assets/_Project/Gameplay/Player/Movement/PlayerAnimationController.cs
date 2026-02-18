using UnityEngine;
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

    public void SetMovement(Vector3 inputDir)
    {
        if (inputDir.x != 0) spriteRenderer.flipX = inputDir.x < 0;
        animator.SetFloat("moveX", inputDir.x);
        animator.SetFloat("moveZ", inputDir.z);
        animator.SetBool("isWalking", inputDir.magnitude > 0.1f);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("attack");
    }

    public void EnableHitbox()
    {
        attack.EnableHitbox();
    }

    public void DisableHitbox()
    {
        attack.DisableHitbox();
    }

    public void OnAttackFinished()
    {
        animator.ResetTrigger("attack");
        playerController.EnableMovement();
    }

    public void TriggerDash()
    {
        animator.SetTrigger("dash");
    }

    public void SetGrounded(bool grounded)
    {
        animator.SetBool("isGrounded", grounded);
    }

    public void TriggerRun()
    {
        animator.SetTrigger("run");
    }
    
}