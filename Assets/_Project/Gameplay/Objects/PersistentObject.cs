using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string objectID;
    private SaveScript saveScript;

    void Awake()
    {
        objectID = gameObject.scene.name + "_" + gameObject.name;

        GameObject gm = GameObject.FindGameObjectWithTag("GameController");

        if (gm == null)
        {
            Debug.LogError("GameController não encontrado na cena!");
            return;
        }

        saveScript = gm.GetComponent<SaveScript>();

        if (saveScript == null)
        {
            Debug.LogError("SaveScript não encontrado no GameController!");
        }
        if (saveScript == null)
        {
            Debug.LogError("SaveScript não encontrado!");
            return;
        }

        if (saveScript.destroyedObjects.Contains(objectID))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Application.isPlaying && saveScript != null)
        {
            if (!saveScript.destroyedObjects.Contains(objectID))
            {
                saveScript.destroyedObjects.Add(objectID);
            }
        }
    }
}
