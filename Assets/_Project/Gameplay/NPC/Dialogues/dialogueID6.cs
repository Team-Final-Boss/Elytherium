using UnityEngine;

public class dialogueID6 : MonoBehaviour
{

    private int dialogoAtual;

    private SaveScript saveScript;
    private dialogueManager dialogueScript;



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
        
            switch (dialogoAtual)
            {
                case 1:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Você finalmente acordou Keira... a queda deve ter sido brusca, mas não deixe isto te distrair do seu real objetivo!";
                    break;
                case 2:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Sua missão principal é coletar o Elytherium deste planeta, não deixe nada desviar você disso!";

                    break;
                case 3:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Vamos explorar este planeta e extrair até o último cristal de elytherium, por que não começa por aquela caverna?";
                    break;
               
                default:
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    break;
            }
        
       
    }
}
