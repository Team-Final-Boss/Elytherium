using UnityEngine;

public class dialogueID4 : MonoBehaviour
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
        if(saveScript.missionComplete <= 6){
        switch (dialogoAtual)
        {
            case 1:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Olá, aqui é um lugar bem importante pra nossa cidade, pois aqui nós temos o gerador, bem há um tempo atrás veio outro como você";
                break;
            case 2:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "E usava a energia dele para o que tivesse atrás daquela porta, mas depois que ele foi embora, nós conseguimos usar a energia";
                playercamera.SetActive(false);
                dialoguecamera.SetActive(true);
            break;
            case 3:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Bem, se você quer passar pela porta, é melhor achar outra maneira, esse é o gerador da cidade.";
                playercamera.SetActive(true);
                dialoguecamera.SetActive(false);
                if(saveScript.missionComplete == 5){
                saveScript.missionComplete = 6;}
                break;
            default:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                break;
        }}
        else if(saveScript.missionComplete == 7)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Muito bem! Você achou outra maneira de passar!";
            dialogueScript.dialogoAtual = 3;
        }
        else if(saveScript.missionComplete == 8)
        {
            dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "O que você fez? Você acabou com a energia da cidade?";
            dialogueScript.dialogoAtual = 3;
        }
    }
}
