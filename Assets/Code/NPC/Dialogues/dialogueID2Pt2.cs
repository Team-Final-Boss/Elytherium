using UnityEngine;

public class dialogueID2Pt2 : MonoBehaviour
{

    public Transition blackscreen;

    private SaveScript saveScript;

    public Vector3 positionTeleport = new Vector3(0, 0, 0);
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
        gameObject.SetActive(false);
        blackscreen.StartTeleport(positionTeleport);
        
    }

    public void otherPass()
    {
        saveScript.missionComplete = 4;
        dialogueScript.dialogoAtual += 1;
        gameObject.SetActive(false);
        blackscreen.StartTeleportOther(positionTeleport);
    }
    
}
