using UnityEngine;

/// <summary>
///  The Attack class manages the player's attack hitbox, enabling and disabling it during attack animations. It detects collisions with other objects and applies damage to any object that implements the Damaged interface. This script should be attached to a child GameObject of the player that has a Collider component set as a trigger, which represents the attack hitbox.
/// </summary>
/// 
/// <remarks>
///  The attack hitbox should be a child of the player GameObject and should have a
/// Collider component with "Is Trigger" enabled. The PlayerAnimationController should call EnableHitbox and DisableHitbox at the appropriate times during the attack animation to ensure that damage is only applied when the hitbox is active.
/// </remarks>

public class Attack : MonoBehaviour
{
    private Collider attackCollider;

    void Awake()
    {
        attackCollider = GetComponent<Collider>();
        attackCollider.enabled = false;
    }

    public void EnableHitbox()
    {
        attackCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        attackCollider.enabled = false;
    }

    /// <summary>
    /// Called when a Collider enters the trigger volume of this attack hitbox.
    /// </summary>
    /// <param name="other">
    /// The Collider that triggered the OnTriggerEnter event.
    /// </param>
    void OnTriggerEnter(Collider other)
    {
        Damaged damaged = other.GetComponent<Damaged>();
        if (damaged != null)
        {
            damaged.TakeDamage(1);
        }
    }
}
