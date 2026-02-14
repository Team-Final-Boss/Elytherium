using UnityEngine;

public class interactScript : MonoBehaviour
{
    public int id = 0;
    public SaveScript saveScript;
    void Start()
    {
        
    }



    public void interacttree()
    {
        switch (id)
        {
            case 0:
                saveScript.saveLocation = 1;
                saveScript.SaveGame();
                break;
            case 1:
            saveScript.LoadGame();
            break;
            default:
                Debug.Log("interact with nothing");
                break;
        }
    }
}
