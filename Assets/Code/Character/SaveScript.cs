using UnityEngine;
using System.IO;

public class SaveScript : MonoBehaviour
{
    public int saveLocation = 0;
    public int missionComplete = 0;

    public int Elytherium = 0;

    public int moral = 50;
   
    private string savePath;

void Awake()
{
    DontDestroyOnLoad(gameObject);
}
 
    void Start()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        data.saveLocation = saveLocation;
        data.missionComplete = missionComplete;
        data.Elytherium = Elytherium;
        data.moral = moral;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Jogo salvo em: " + savePath);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            saveLocation = data.saveLocation;
            missionComplete = data.missionComplete;
            Elytherium = data.Elytherium;
            moral = data.moral;

            Debug.Log("Jogo carregado!");
        }
        else
        {
            Debug.Log("Nenhum save encontrado.");
        }
    }
}

