using UnityEngine;

public class Attack : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
        }
    }
}
