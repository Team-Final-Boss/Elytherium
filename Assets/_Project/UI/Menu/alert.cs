using UnityEngine;
using UnityEngine.SceneManagement;

public class alert : MonoBehaviour
{
    public int sceneID = 0;

    private SaveScript saveScript;

   

    GameObject player;
    MoveScript moveScript;

    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
            Debug.LogError("GameController não encontrado na cena!");
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();

        if (saveScript == null)
        {
            Debug.LogError("SaveScript não encontrado no GameController!");
        }

        player = GameObject.FindGameObjectWithTag("Player");
        moveScript = player.GetComponent<MoveScript>();
    }
    public void Confirm()
    {
        SceneManager.LoadScene(sceneID);
    }
    public void Cancel()
    {
        moveScript.enabled = true;

        gameObject.SetActive(false);
    }

    public void chargeBattery()
    {
        GameObject battery = GameObject.FindGameObjectWithTag("Battery");
        if (battery != null)
        {
            if(saveScript.Elytherium >= 5)
            {
            saveScript.Elytherium -= 5;
            ChargedBattery chargedBattery = battery.GetComponent<ChargedBattery>();
            chargedBattery.isLoaded = true;
            moveScript.enabled = true;
            gameObject.SetActive(false);
        }}
        else
        {
            Debug.Log("Bateria não encontrada!");
        }

    }

    public void UseGenerator()
    {

        saveScript.missionComplete = 8;
        saveScript.moral += 10;
        moveScript.enabled = true;

        gameObject.SetActive(false);
    }
}
