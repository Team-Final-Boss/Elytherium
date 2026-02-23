
using UnityEngine;

public class missionTxt : MonoBehaviour
{
    private SaveScript saveScript;
    public TMPro.TMP_Text txt;

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

        if (saveScript.missionComplete == 0)
        {
            txt.text = "Explore a caverna";
        }
        else if(saveScript.missionComplete == 1)
        {
            txt.text = "Encontre um caminho até o machado";
        }
        else if(saveScript.missionComplete == 2)
        {
            txt.text = "Saia da caverna";
        }
        else if(saveScript.missionComplete == 3)
        {
            txt.text = "Encontre uma maneira de passar pelo rio";
        }
        else if(saveScript.missionComplete == 4)
        {
            txt.text = "Envie o Elytherium coletado para a base e continue avançando";
        }
        else if(saveScript.missionComplete  <= 6)
        {
             txt.text = "Encontre uma maneira de entrar no laboratório";
        }
        else if(saveScript.missionComplete < 9)
        {
            txt.text = "Entre no laboratório";
        }
        else if(saveScript.missionComplete == 9)
        {
            txt.text = "Explore o laboratório";
        }

           
    }
}
