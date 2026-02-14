using UnityEngine;

public class interact : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Interactable")
        {
            Debug.Log("Interagiu");
            other.gameObject.GetComponent<interactScript>().interacttree();
        }
    }
}
