using UnityEngine;

public class dialogueID5 : MonoBehaviour
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
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "[Os registros aqui mostram experimentos com a bactéria Beta que Alpha nunca admitiu.]";
                break;
        }
        
    }
}
