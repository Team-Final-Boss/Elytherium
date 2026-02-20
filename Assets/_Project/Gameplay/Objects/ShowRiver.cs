using UnityEngine;

public class ShowRiver : MonoBehaviour
{

    private SaveScript saveScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
            Debug.LogError("GameController não encontrado na cena!");
            return;
        }
        saveScript = gm.GetComponent<SaveScript>();
        
        gameObject.SetActive(saveScript.river);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
