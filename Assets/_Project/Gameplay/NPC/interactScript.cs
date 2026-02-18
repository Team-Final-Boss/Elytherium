using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScript : MonoBehaviour
{
    public int id = 0;

    private SaveScript saveScript;

    public GameObject alert;
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

    if (alert == null)
    {
        alert = GameObject.FindGameObjectWithTag("Alert");
    }
}

    public void interactTree()
    {
        switch (id)
        {
            case 0:
                saveScript.saveLocation = SceneManager.GetActiveScene().buildIndex;
                saveScript.timesaved += 1;
                saveScript.SaveGame();
                break;
            case 1:
                saveScript.LoadGame();
                break;
            case 2:
                SceneManager.LoadScene(3);
                break;
            case 3:
                dialogueScript dialogue = GetComponent<dialogueScript>();
                if (dialogue != null)
                    dialogue.showDialogue();
                else
                    Debug.LogError("dialogueScript não encontrado.");
                break;
            case 4:
                saveScript.missionComplete = 2;
                TMPro.TextMeshProUGUI text = GameObject.FindGameObjectWithTag("InteractText").GetComponent<TMPro.TextMeshProUGUI>();
                text.text = "";
                Destroy(gameObject);
                break;
            case 5:
                if(saveScript.missionComplete == 2){
                saveScript.missionComplete = 3;}
                alert.SetActive(true);
                break;
            case 6:
                teleporter teleport = GetComponent<teleporter>();
                teleport.teleport();
                break;
            default:
                Debug.Log("interact with nothing");
                break;
        }
    }
}
