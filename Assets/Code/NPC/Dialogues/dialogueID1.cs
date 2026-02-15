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
        if(saveScript.missionComplete == 0){
        switch (dialogoAtual)
        {
            case 1:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Ah... oi? Quem é você? Também busca ir pra cidade? Bem não importa muito... a questão é que com essas pedrass no caminho, não tem como prosseguir.";
                break;
            case 2:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Mas... eu tenho uma ideia, um pouco mais a frente da caverna tem uma mineradora portatil, ela pode quebrar essas pedras, se você conseguir chegar até lá, é claro. Eu queria tentar mas esse precipio me da arrepios";
                playercamera.SetActive(false);
                dialoguecamera.SetActive(true);
            break;
            case 3:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Te desejo boa sorte";
                playercamera.SetActive(true);
                dialoguecamera.SetActive(false);
                saveScript.missionComplete = 1;
                break;
            default:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                break;
        }}
        else if(saveScript.missionComplete == 1)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "O que está esperando? É a única maneira de sair da caverna";
            dialogueScript.dialogoAtual = 3;
        }
    }
}
