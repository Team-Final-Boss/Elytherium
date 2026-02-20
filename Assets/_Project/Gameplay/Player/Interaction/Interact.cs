using UnityEngine;
using TMPro;

public class interact : MonoBehaviour
{
    private interactScript currentObject;

    public TMPro.TextMeshProUGUI text;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if(text != null){
            text.text = "Pressione E para interagir";}
            currentObject = other.GetComponent<interactScript>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if(text != null){
            text.text = "";}
            currentObject = null;
        }
    }

    void Update()
    {
        if (currentObject != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interagiu");
            currentObject.interactTree();
        }
    }
}
