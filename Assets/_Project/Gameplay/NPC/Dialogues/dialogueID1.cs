using UnityEngine;

public class dialogueID1 : MonoBehaviour
{

    private int dialogoAtual;

    private SaveScript saveScript;
    private dialogueManager dialogueScript;

    public GameObject dialoguecamera;
    public GameObject playercamera;

    public GameObject dialogueText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueScript = GetComponent<dialogueManager>();
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();

    }

    // Update is called once per frame
    void Update()
    {
        dialogoAtual = dialogueScript.dialogoAtual;
        dialogueManager();

    }

    void dialogueManager()
    {
        if (saveScript.missionComplete == 0)
        {
            switch (dialogoAtual)
            {
                case 1:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Ora... um rosto novo? Ou apenas mais uma sombra de Alpha? Se busca a Cidade, sinto dizer que o caminho morreu sob essas pedras. O Elytherium que nos dava vida agora nos isola.";
                    break;
                case 2:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Mas... eu tenho uma ideia, um pouco mais a frente da caverna tem um machado portatil, ela pode quebrar essas pedras, se você conseguir chegar até lá, é claro. Eu queria tentar mas esse precipio me da arrepios";
                    playercamera.SetActive(false);
                    dialoguecamera.SetActive(true);
                    break;
                case 3:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Você está infectada? Bem... o tempo não para em Aerium, estrangeira. Ou você move as pedras, ou as pedras serão seu túmulo. O que decidiu?Te desejo boa sorte";
                    playercamera.SetActive(true);
                    dialoguecamera.SetActive(false);
                    saveScript.missionComplete = 1;
                    break;
               
                default:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    break;
            }
        }
        else if (saveScript.missionComplete == 1)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "O que está esperando? É a única maneira de sair da caverna";
            dialogueScript.dialogoAtual = 3;
        }
        else if (saveScript.missionComplete == 2)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Você conseguiu, agora vamos sair daqui!";
            dialogueScript.dialogoAtual = 3;
        }
    }
}
