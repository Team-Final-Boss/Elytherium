using UnityEngine;

public class teleporter1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transition blackscreen;

    public Transform positionTeleport;

    public void teleport1()
    {
        blackscreen.StartTeleport(positionTeleport.position);
    }
}
