using UnityEngine;

public class River : MonoBehaviour
{

    public Transform river;

    public int rocksReceived = 0;

    public Vector3 position2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            river.position = position2;
        }
    }
}
