using UnityEngine;

public class teleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transition blackscreen;

    public Vector3 positionTeleport = new Vector3(0, 0, 0);

    public void teleport()
    {
        blackscreen.StartTeleport(positionTeleport);
    }
}
