
using UnityEngine;

public class axeicon : MonoBehaviour
{
    private SaveScript saveScript;
    private ConfigScript config;
    public TMPro.TMP_Text txt;
    public GameObject AxeIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
           
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();
        config = gm.GetComponent<ConfigScript>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (saveScript.missionComplete >= 2)
        {
            AxeIcon.SetActive(true);
            if (config.controls == 0)
            {
                txt.text = "Z";
            }
            else if (config.controls == 1)
            {
                txt.text = "SPACE";
            }
        }
           
    }
}
