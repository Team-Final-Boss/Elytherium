using UnityEngine;

public class dialogueManager : MonoBehaviour
{
   public int dialogoAtual = 1;

   public dialogueScript Dialogue;
   private const int totalDialogos = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E))
       {
           passDialogue();
       }
    }

    public void passDialogue()
    {
        if(dialogoAtual < totalDialogos )
        {
            dialogoAtual += 1;
        }
        else
        {
            dialogoAtual = 1;
            Dialogue.hideDialogue();
        }
    }

    
}
