using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScript : MonoBehaviour
{
    public int id = 0;

    private SaveScript saveScript;
    private TMPro.TextMeshProUGUI text;

    private GameObject player;
    private MoveScript moveScript;

    [SerializeField] private GameObject saveScreen;
    public GameObject alert;
    public GameObject alert2;

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

                if (saveScreen != null)
                {
                    saveScreen.SetActive(!saveScreen.activeSelf);

                    player = GameObject.FindGameObjectWithTag("Player");
                    moveScript = player.GetComponent<MoveScript>();

                    if (moveScript != null)
                    {
                        moveScript.enabled = !saveScreen.activeSelf;
                    }
                    else
                    {
                        Debug.LogError("MoveScript não encontrado no Player!");
                    }
                }
                else
                {
                    Debug.LogError("SaveScreen não encontrado na cena!");
                }

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

                text = GameObject
                    .FindGameObjectWithTag("InteractText")
                    .GetComponent<TMPro.TextMeshProUGUI>();

                text.text = "";

                Destroy(gameObject);

                break;

            case 5:

                if (saveScript.missionComplete == 2)
                {
                    saveScript.missionComplete = 3;
                }

                alert.SetActive(!alert.activeSelf);

                player = GameObject.FindGameObjectWithTag("Player");
                moveScript = player.GetComponent<MoveScript>();

                if (moveScript != null)
                {
                    moveScript.enabled = !moveScript.enabled;
                }
                else
                {
                    Debug.LogError("MoveScript não encontrado no Player!");
                }

                break;

            case 6:

                teleporter teleport = GetComponent<teleporter>();
                teleport.teleport();

                break;

            case 7:

                SceneManager.LoadScene(5);

                if (saveScript.missionComplete < 5)
                {
                    saveScript.missionComplete = 5;
                }

                break;

            case 8:

                SceneManager.LoadScene(4);

                break;

            case 9:

                GameObject menuCanvas = GameObject.FindGameObjectWithTag("Menu");

                if (menuCanvas != null)
                {
                    Transform alertTransform = menuCanvas.transform.Find("Alert Battery");

                    if (alertTransform != null)
                    {
                        alert2 = alertTransform.gameObject;
                        Debug.Log("Alert2 encontrado!");

                        // Só ativa/desativa se encontrou
                        alert2.SetActive(!alert2.activeSelf);
                    }
                    else
                    {
                        Debug.LogError("Alert2 não encontrado dentro do Menu!");
                    }
                }
                else
                {
                    Debug.LogError("Canvas com tag 'Menu' não encontrado!");
                }

                player = GameObject.FindGameObjectWithTag("Player");
                moveScript = player?.GetComponent<MoveScript>();

                if (moveScript != null)
                {
                    text = GameObject
                        .FindGameObjectWithTag("InteractText")
                        ?.GetComponent<TMPro.TextMeshProUGUI>();

                    if (text != null)
                        text.text = "";

                    moveScript.enabled = !moveScript.enabled;
                }
                else
                {
                    Debug.LogError("MoveScript não encontrado no Player!");
                }

                break;
            default:

                Debug.Log("interact with nothing");
                break;
        }
    }
}