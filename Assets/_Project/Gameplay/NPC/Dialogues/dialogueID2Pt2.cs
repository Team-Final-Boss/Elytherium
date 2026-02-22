using UnityEngine;

public class dialogueID2Pt2 : MonoBehaviour
{

    public GameObject bridge;

    public Transition blackscreen;

    private SaveScript saveScript;

    public Vector3 positionTeleportOther = new Vector3(0, 0, 0);
    public dialogueManager dialogueScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();
    }

    public void youPass()
    {
        saveScript.missionComplete = 4;
        dialogueScript.dialogoAtual += 1;
        blackscreen.StartTeleport(positionTeleportOther);
        saveScript.moral += 10;
        
        dialogueScript.passDialogue();
        bridge.SetActive(false);
        gameObject.SetActive(false);
        
    }

    public void otherPass()
    {
        saveScript.missionComplete = 4;
        dialogueScript.dialogoAtual += 1;
        blackscreen.StartTeleportOther(positionTeleportOther);
        saveScript.moral -= 10;
        
        dialogueScript.passDialogue();
        bridge.SetActive(false);
        gameObject.SetActive(false);
    }
    
}
