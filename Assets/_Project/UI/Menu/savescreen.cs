using UnityEngine;
using UnityEngine.SceneManagement;

public class savescreen : MonoBehaviour
{
     private SaveScript saveScript;

     private MoveScript movescript;

     public TMPro.TMP_Text elytheriumText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    GameObject gm = GameObject.FindGameObjectWithTag("GameController");

    if (gm == null)
    {
        Debug.LogError("GameController NÃO encontrado!");
        return;
    }

    saveScript = gm.GetComponent<SaveScript>();

    GameObject player = GameObject.FindGameObjectWithTag("Player");

    if (player == null)
    {
        Debug.LogError("Player NÃO encontrado!");
        return;
    }

    movescript = player.GetComponent<MoveScript>();

    if (movescript == null)
    {
        Debug.LogError("MoveScript NÃO encontrado no Player!");
    }
}

    public void CloseSaveScreen()
    {
        movescript.enabled = true;

        gameObject.SetActive(false);
    }

    public void SaveClick()
    {
        saveScript.saveLocation = SceneManager.GetActiveScene().buildIndex;
        saveScript.timesaved += 1;
        saveScript.SaveGame();}

    public void SendElytherium()
    {
        saveScript.moral += saveScript.Elytherium * 2;
        saveScript.Elytherium = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elytheriumText.text = "Enviar " + saveScript.Elytherium.ToString() + " Elytherium para a base.";
    }
}
