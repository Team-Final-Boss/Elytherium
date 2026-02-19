using UnityEngine;
using System.IO;

public class ConfigScript : MonoBehaviour
{
    public int controls = 0;
    public int volume = 50;

    public int brightness = 50;

    public int language = 0;

   public int timesaved = 0;
    private string savePath;

void Awake()
{
    DontDestroyOnLoad(gameObject);
}


 
    void Start()
    {
        savePath = Application.persistentDataPath + "/config.json";
    }

    public void SaveConfig()
    {
        ConfigData data = new ConfigData();

        data.controls = controls;
        data.volume = volume;
        data.brightness = brightness;
        data.language = language;
        data.timesaved = timesaved;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Configurações salvas em: " + savePath);
    }

    public void LoadConfig()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            ConfigData data = JsonUtility.FromJson<ConfigData>(json);

            controls = data.controls;
            volume = data.volume;
            brightness = data.brightness;
            language = data.language;

            Debug.Log("Configurações carregadas!");
        }
        else
        {
            Debug.Log("Nenhuma configuração encontrada.");
        }
    }
}

