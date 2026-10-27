using UnityEngine;

public class dialogueID7 : MonoBehaviour
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
        switch (dialogoAtual)
        {
            case 1:
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nós somos pacíficos e não ergueremos as mãos contra você, mas não confunda nossa misericórdia com fraqueza. O que Alpha chama de 'recurso', nós chamamos de 'vida'. Se levar esses Elytheriums, você salvará sua casa, mas deixará um cemitério para trás. Pense bem: o silêncio deste mundo morto será sua única companhia na viagem de volta, e sua decisão será sua própria prisão.";
                break;
        }
        
    }
}
