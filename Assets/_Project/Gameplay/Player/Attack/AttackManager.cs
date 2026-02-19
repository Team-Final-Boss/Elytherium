using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private SaveScript saveScript;

    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        if (gm != null)
        {
            saveScript = gm.GetComponent<SaveScript>();
        }
        else
        {
            Debug.LogError("[AttackManager] GameController not found in scene. Verifique se o GameController tem a tag correta!", this);
        }

        UpdateWeaponState();
    }

// Added the function call to update, so it can detect when the value is changed in the scene.
    public void Update()
    {
        UpdateWeaponState();
    }
    
    public void UpdateWeaponState()
    {
        if (saveScript == null || playerController == null) 
        {
            Debug.LogError("[AttackManager] SaveScript ou PlayerController não encontrado. Verifique as referências no inspector!", this);
            return;
        }
      // Changed the value from 0 to 2
        bool isWeaponUnlocked = saveScript.missionComplete >= 2;
        playerController.SetAttackUnlocked(isWeaponUnlocked); 
    }
}
