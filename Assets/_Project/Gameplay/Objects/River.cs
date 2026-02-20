using UnityEngine;

public class River : MonoBehaviour
{

    public Transform river;

    public GameObject teleporter;

    private SaveScript saveScript;



    public int rocksReceived = 0;

    public Vector3 position2;
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

        if (!saveScript.river)
        {
            river.localPosition = position2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateRiver();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
            rocksReceived++;
        }
    }

    void updateRiver()
    {
        if (rocksReceived == 5)
        {
            river.localPosition = position2;
            teleporter.SetActive(true);
            saveScript.river = false;
        }
    }
}
