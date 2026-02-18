using UnityEngine;

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

    void OnTriggerEnter(Collider other)
    {
        Damaged damaged = other.GetComponent<Damaged>();
        if (damaged != null)
        {
            damaged.TakeDamage(1);
        }
    }
}
