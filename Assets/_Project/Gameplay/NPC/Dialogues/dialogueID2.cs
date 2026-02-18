using UnityEngine;

public class dialogueID2 : MonoBehaviour
{

    private int dialogoAtual;

    private SaveScript saveScript;
    private dialogueManager dialogueScript;

    public GameObject alert;

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
        if(saveScript.missionComplete == 3){
        switch (dialogoAtual)
        {
            case 1:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Temos um problema, esta ponte é a base de energia, e ela está fraca, não acho que vai dar pra passar nos dois";
                break;
            case 2:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Eu preciso chegar com urgência na cidade, você poderia me deixar passar e procurar por outra maneira?";
            break;
            case 3:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "[ALERTA] Vamos passar logo, inventa qualquer coisa, não podemos perder tempo com isso.";
                break;
            case 4: 
            
            alert.SetActive(true);
            dialogueScript.NotpressToPass = true;
            gameObject.SetActive(false);
            
            break;
            default:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                
                break;
        }}
    }
}
