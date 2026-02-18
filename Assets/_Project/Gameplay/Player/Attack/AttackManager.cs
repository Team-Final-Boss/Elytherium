using UnityEngine;

public class AttackManager : MonoBehaviour
{
     private SaveScript saveScript;
     public PlayerAttack weapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        saveScript = gm.GetComponent<SaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(saveScript.missionComplete >= 2)
        {
            weapon.enabled = true;
        }
        else
        {
            weapon.enabled = false;
        }
    }
}
