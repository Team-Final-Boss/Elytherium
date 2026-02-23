using UnityEngine;

public class dialogueID2 : MonoBehaviour
{

    private int dialogoAtual;

    private SaveScript saveScript;
    private dialogueManager dialogueScript;

    public GameObject alert;

    public GameObject dialoguecamera;
    public GameObject playercamera;

    public GameObject npcImage;

    public GameObject forceImage;

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
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Escute, a energia desta ponte está oscilando. A carga é insuficiente para manter a integridade molecular de dois corpos ao mesmo tempo. Ela vai colapsar";
                break;
            case 2:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Meu povo me espera com urgência. Keira, por favor... deixe-me passar. Você é jovem, tem o equipamento de Alpha. Certamente encontrará outro modo de cruzar";
            break;
            case 3:
            npcImage.SetActive(false);
            forceImage.SetActive(true);

                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Negativo, Keira. Não ceda. Nosso cronograma não permite atrasos por cortesia nativa. Invente uma desculpa e passe primeiro. O objetivo é a reserva";
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
