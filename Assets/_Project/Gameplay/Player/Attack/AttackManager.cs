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
        Debug.Log("[UpdateWeaponState] Verificando estado da arma.");
    }
    
    // for some reason isnt working
    public void UpdateWeaponState()
    {
        if (saveScript == null || playerController == null) 
        {
            Debug.LogError("[AttackManager] SaveScript ou PlayerController não encontrado. Verifique as referências no inspector!", this);
            return;
        }
        
        Debug.Log($"[UpdateWeaponState] Chamando SetAttackUnlocked com: {saveScript.missionComplete >= 0}");

        bool isWeaponUnlocked = saveScript.missionComplete >= 0;
        playerController.SetAttackUnlocked(isWeaponUnlocked); 
    }
}
