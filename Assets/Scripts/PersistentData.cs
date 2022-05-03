using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public string playerName;
    public string bestPlayerName = "Name";
    public int highscore = 0;

    private string saveFile = "/savefile.json";

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    private class SaveData
    {
        public string bestPlayerName;
        public int highscore;
    }

    public void SaveBestPlayer(
        string playerName,
        int score
        )
    {
        SaveData data = new SaveData();
        data.bestPlayerName = playerName;
        data.highscore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(
            Application.persistentDataPath
                + saveFile,
            json
            );
    }

    public void LoadPlayerName()
    {
        string path = 
            Application.persistentDataPath
            + saveFile;

        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        SaveData data = 
            JsonUtility.FromJson<SaveData>(json);
        
        bestPlayerName = data.bestPlayerName;
        highscore = data.highscore;
    }
}
