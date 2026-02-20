using UnityEngine;

public class Charged : MonoBehaviour
{
    public int charge = 0;

    public ChargedBattery battery;

    public Transition transition;

    void Start()
    {
        GameObject batteryGO = GameObject.FindGameObjectWithTag("Battery");
        if (batteryGO != null)
        {
            battery = batteryGO.GetComponent<ChargedBattery>();
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TakeDamage(int damage)
    {
        if (battery.isLoaded && battery.isOnPosition)
        {
            charge += damage;
            if (charge >= 5)
            {
                battery.isCharged = true;
            }
        }

    }
}
