using UnityEngine;

public class ChargedBattery : MonoBehaviour
{
    public bool isCharged = false;
    public bool isLoaded = false;

    public bool isOnPosition = false;

    private Rigidbody rb;

    public GameObject interact;

void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isCharged && isOnPosition)
        {
            rb.isKinematic = true;
        }
        else if (isCharged)
        {
            rb.isKinematic = false;
        }

        if (isLoaded)
        {
            Destroy(interact);
        }
    }
}
