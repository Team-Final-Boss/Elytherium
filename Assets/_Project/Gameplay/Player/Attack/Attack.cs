using UnityEngine;
using System.Collections;

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

    [Header("Hitbox Offsets")]
    [SerializeField] private Vector3 leftPos = new Vector3(-0.789f, -0.172f, -0.041f);
    [SerializeField] private Vector3 rightPos = new Vector3(0.785f, -0.172f, -0.041f);
    [SerializeField] private Vector3 upPos = new Vector3(-0.029f, -0.172f, 1.389f);
    [SerializeField] private Vector3 downPos = new Vector3(-0.029f, -0.172f, -1.320f);

    private Collider attackCollider;
    private Transform hitboxTransform;

    #region Unity Methods
    /// <summary>
    ///   Awake is called when the script instance is being loaded. It initializes references to the Collider component and caches the Transform for performance. It also ensures that the attack hitbox starts disabled and logs an error if the Collider component is not found.
     /// </summary>
     /// <remarks>
     ///   The Collider component must be set as a trigger for the attack hitbox to function correctly. If the Collider is not found, an error message will be logged to help with debugging the scene setup.
     /// </remarks>
    void Awake()
    {
        attackCollider = GetComponent<Collider>();
        hitboxTransform = transform; // caching transform reference for performance

        if (attackCollider == null)
        {
            Debug.LogError("[Attack] Collider component not found. Verifique se o hitbox tem um Collider com 'Is Trigger' habilitado!", this);
        }
        attackCollider.enabled = false;
    }


    void Update()
    {
        // if (attackCollider.enabled)
        // {
        //     Debug.LogWarning($"[🚨 FANTASMA] O Colisor está LIGADO! Frame: {Time.frameCount}", this);
        // }
    }

    #endregion

    

    #region Control Methods
    /// <summary>
    ///     UpdateHitboxPosition is called by the PlayerAnimationController to update the position of the attack hitbox based on the player's facing direction. It uses predefined offsets for left, right, up, and down directions to position the hitbox correctly relative to the player.
    /// </summary>    
    /// <param name="facingDirection">
    /// The direction the player is facing, represented as a Vector2.
    /// </param>
    public void UpdateHitboxPosition(Vector2 facingDirection)
    {
        if (Mathf.Abs(facingDirection.x) > Mathf.Abs(facingDirection.y))
        {
            hitboxTransform.localPosition = facingDirection.x > 0 ? rightPos : leftPos;
        }
        else
        {
            hitboxTransform.localPosition = facingDirection.y > 0 ? upPos : downPos;
        }
    }

    public void EnableHitbox()
    {
        attackCollider.enabled = true;
        
        Debug.Log("[Attack] Hitbox Habilitado.");
    }

    public void DisableHitbox()
    {
        attackCollider.enabled = false;
        Debug.Log("[Attack] Hitbox desabilitado.");
    }

    /// <summary>
    /// Called when a Collider enters the trigger volume of this attack hitbox.
    /// </summary>
    /// <param name="other">
    /// The Collider that triggered the OnTriggerEnter event.
    /// </param>
    void OnTriggerEnter(Collider other)
    {

        if (!attackCollider.enabled) 
        {
            return; 
        }

        if (other.CompareTag("Damaged"))
        {
            if (other.TryGetComponent(out Damaged damaged))
            {
                damaged.TakeDamage(1);
                StartCoroutine(ShakeTarget(other.transform));
                
                
            }
        }
        if (other.CompareTag("Destructible"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Charger"))
        {
            if (other.TryGetComponent(out Charged charged))
            {
                StartCoroutine(ShakeTarget(other.transform));
                charged.TakeDamage(1);
            }
        }
        if (other.CompareTag("Elytherium"))
        {
            if (other.TryGetComponent(out Elytherium elytherium))
            {
                elytherium.CollectElytherium();
            }
        }
    }   

private IEnumerator ShakeTarget(Transform target)
{
    if (target == null) yield break;

    Vector3 original = target.localPosition;
    float duration = 0.15f;
    float strength = 0.1f;
    float timer = 0f;

    while (timer < duration)
    {
        if (target == null) yield break; // 🔥 ESSENCIAL

        float offsetX = Mathf.Sin(timer * 40f) * strength;
        target.localPosition = original + new Vector3(offsetX, 0f, 0f);

        timer += Time.deltaTime;
        yield return null;
    }

    if (target != null)
        target.localPosition = original;
}

    #endregion
}
