using UnityEngine;
using UnityEngine.SceneManagement;

public class config : MonoBehaviour
{

    public TMPro.TextMeshProUGUI controlsText;
    private ConfigScript configScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (configScript.controls == 0)
        {
            controlsText.text = "Arrow Keys";}
        else if (configScript.controls == 1)
        {
            controlsText.text = "WASD";}
    }


    public void setControls()
    {
        if (configScript.controls == 0)
        {
            configScript.controls = 1;
            
        }
        else if (configScript.controls == 1)
        {
            configScript.controls = 0;
        }
    }

    public void saveChanges()
    {
       
        configScript.SaveConfig();
        SceneManager.LoadScene(8);
    }

    public void exitNoSave()
    {
        SceneManager.LoadScene(8);
    }
}
