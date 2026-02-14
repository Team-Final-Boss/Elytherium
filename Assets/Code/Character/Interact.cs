using UnityEngine;

public class interact : MonoBehaviour
{
    private interactScript objetoAtual;
    public TMPro.TextMeshProUGUI text;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            text.text = "Press E to interact";
            objetoAtual = other.GetComponent<interactScript>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            text.text = "";
            objetoAtual = null;
        }
    }

    void Update()
    {
        if (objetoAtual != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interagiu");
            objetoAtual.interacttree();
        }
    }
}
