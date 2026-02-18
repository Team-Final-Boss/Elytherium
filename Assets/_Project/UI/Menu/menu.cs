using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   private SaveScript saveScript;
   private ConfigScript configScript;
   public GameObject continueButton;

   public GameObject confirmScreen;

   private int loadtimes = 0;

    void Start()
    {
         GameObject gm = GameObject.FindGameObjectWithTag("GameController");
         saveScript = gm.GetComponent<SaveScript>();
         configScript = gm.GetComponent<ConfigScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(loadtimes == 0)
        {
            loadMenu();
            loadtimes++;
        }
       
        
    }

    void loadMenu()
    {
        saveScript.LoadGame();
        configScript.LoadConfig();

        if (saveScript.timesaved > 0)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void newGame()
    {
        saveScript.saveLocation = 0;
        saveScript.missionComplete = 0;
        saveScript.Elytherium = 0;
        saveScript.moral = 50;
        saveScript.timesaved = 0;
        
        saveScript.SaveGame();
        SceneManager.LoadScene(1);
    }

    public void continueGame()
    {
        SceneManager.LoadScene(saveScript.saveLocation);
    }

    public void config()
    {
        SceneManager.LoadScene(2);
    }

    public void newGameConfirm()
    {
        confirmScreen.SetActive(true);
    }

    public void closeNewGameConfirm()
    {
        confirmScreen.SetActive(false);
    }

    public void exit(){
        Application.Quit();
    }
}
