using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
/// <remarks>
/// 
/// </remarks>
public class Attack : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Damaged")
        {
            Damaged damaged = other.gameObject.GetComponent<Damaged>();
            if (damaged != null)
            {
                damaged.TakeDamage(1);
            }
        }
    }
}
