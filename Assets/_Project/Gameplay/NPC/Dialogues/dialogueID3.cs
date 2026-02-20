using UnityEngine;

public class dialogueID3 : MonoBehaviour
{

    private int dialogoAtual;

    public GameObject alert;

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
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Ah olá, vejo que você é novo aqui, veio de outro planeta? você já ouviu falar sobre o Elytherium?";
                break;
            case 2:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "O Elytherium é um material vital para a vida no planeta, de alguma maneira, sua permanencia em nossa órbita, garante toda a segurança do planeta";

                break;
            case 3:
                if (saveScript.Elytherium > 0)
                {
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Vejo que carrega elytherium com você, poderia me dar por favor? É realmente muito importante pra nossa sobrevivência, por favor não tire daqui";
                }
                else
                {
                    dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Caso encontre algum elytherium, por favor traga pra mim, não o leve embora";
                }
                break;
            case 4:
                if (saveScript.Elytherium > 0)
                {
                    alert.SetActive(true);
                    dialogueScript.NotpressToPass = true;
                    gameObject.SetActive(false);
                }
                else { dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Muito obrigado"; }
                break;
            default:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                break;
        }

    }
}
