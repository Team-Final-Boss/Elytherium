using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    private SaveScript saveScript;

    public int missionNecessary = 3;

   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();

        if(saveScript.missionComplete == missionNecessary)
        {
            
            dialogueScript dialogueScript = GetComponent<dialogueScript>();
            dialogueScript.showDialogue();}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
