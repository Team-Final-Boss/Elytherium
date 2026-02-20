using UnityEngine;

public class Elytherium : MonoBehaviour
{

    private SaveScript saveScript;
    public int elytheriumAmount = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         GameObject gm = GameObject.FindGameObjectWithTag("GameController");
         saveScript = gm.GetComponent<SaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectElytherium()
    {
        saveScript.Elytherium += elytheriumAmount;
        Destroy(gameObject);
    }
}
