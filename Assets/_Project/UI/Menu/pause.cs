using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{

    public GameObject player;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

 

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            Time.timeScale = 0f;
            player.GetComponent<MoveScript>().enabled = false;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
            Time.timeScale = 1f;
            player.GetComponent<MoveScript>().enabled = true;
            pauseMenu.SetActive(false);
        }
    }

    public void unpauseGame()
    {
        Time.timeScale = 1f;
        player.GetComponent<MoveScript>().enabled = true;
        pauseMenu.SetActive(false);
    }

    public void exitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
