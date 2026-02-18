using UnityEngine;
using UnityEngine.SceneManagement;

public class alert : MonoBehaviour
{
    public int sceneID = 0;
    public void Confirm(){
        SceneManager.LoadScene(sceneID);
    }
    public void Cancel(){
        gameObject.SetActive(false);
    }
}
