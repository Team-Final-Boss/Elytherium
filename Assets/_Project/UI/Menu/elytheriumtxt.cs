
using UnityEngine;

public class elytheriumtxtr : MonoBehaviour
{
    private SaveScript saveScript;
    public TMPro.TMP_Text moralText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
           
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moralText.text = "Elytherium coletado: " + saveScript.Elytherium.ToString();
    }
}
