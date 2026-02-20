using UnityEngine;

public class dialogueID3Pt2 : MonoBehaviour
{




    private SaveScript saveScript;

    public dialogueManager dialogueScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();
    }

    public void saveElytherium()
    {
        dialogueScript.dialogoAtual += 1;
        saveScript.moral -= saveScript.Elytherium * 2;
        saveScript.Elytherium = 0;
        
        
        dialogueScript.passDialogue();
        gameObject.SetActive(false);
        
    }

    public void notSave()
    {
        dialogueScript.dialogoAtual += 1;
        
        dialogueScript.passDialogue();
        gameObject.SetActive(false);
    }
    
}
