using UnityEngine;

public class VerifyMission : MonoBehaviour
{

    public interactScript interact;

    private SaveScript saveScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
            Debug.LogError("GameController não encontrado na cena!");
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();

        if (saveScript == null)
        {
            Debug.LogError("SaveScript não encontrado no GameController!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(saveScript.missionComplete == 8)
        {
            interact.enabled = false;
        }
    }
}
