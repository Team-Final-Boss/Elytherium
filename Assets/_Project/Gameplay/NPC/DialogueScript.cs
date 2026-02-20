using UnityEngine;

public class dialogueScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public GameObject dialogueBox;
   public PlayerController moveScript;

   public GameObject interactArea;
    public TMPro.TextMeshProUGUI textInteract;
    void Start()
    {
        if(moveScript == null){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        moveScript = player.GetComponent<PlayerController>();}
    }
   
   public void showDialogue()
    {
        interactArea.SetActive(false);

        moveScript.DisableMovement();
        textInteract.text = "";
        dialogueBox.SetActive(true);
    }

    public void hideDialogue()
    {
        moveScript.EnableMovement();
        dialogueBox.SetActive(false);
        interactArea.SetActive(true);
    }
}
