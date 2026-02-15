using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScript : MonoBehaviour
{
    public int id = 0;
    private SaveScript saveScript;
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();
    }



    public void interacttree()
    {
        switch (id)
        {
            case 0:
                saveScript.saveLocation = 1;
                saveScript.timesaved += 1;
                saveScript.SaveGame();
                break;
            case 1:
            saveScript.LoadGame();
            break;
            case 2:
            SceneManager.LoadScene(3);
            break;
            default:
                Debug.Log("interact with nothing");
                break;
        }
    }
}
