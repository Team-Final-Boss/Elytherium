using UnityEngine;
public class PlayerAnimationController : MonoBehaviour {
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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