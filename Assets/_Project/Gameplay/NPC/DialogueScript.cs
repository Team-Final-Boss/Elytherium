using UnityEngine;

public class dialogueScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public GameObject dialogueBox;
   public MoveScript moveScript;

   public GameObject interactArea;
    public TMPro.TextMeshProUGUI textInteract;
    void Start()
    {
        if(moveScript == null){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        moveScript = player.GetComponent<MoveScript>();}
    }
   
   public void showDialogue()
    {
        interactArea.SetActive(false);

        moveScript.enabled = false;
        textInteract.text = "";
        dialogueBox.SetActive(true);
    }

    public void hideDialogue()
    {
        moveScript.enabled = true;
        dialogueBox.SetActive(false);
        interactArea.SetActive(true);
    }
}
