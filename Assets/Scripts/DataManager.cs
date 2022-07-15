using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string playerName;
    public string bestPlayerName;
    public int highScore;
    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int highScore;
    }

    public void SaveGameData()
    {
        //new SaveData instance
        SaveData data = new SaveData();
        //fill new instance with current best stats
        data.bestPlayerName = bestPlayerName;
        data.highScore = highScore;

        //turn the instance into JSON using JsonUtility
        string json = JsonUtility.ToJson(data);

        //Write the string to a path as a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            highScore = data.highScore;
        }
    }

    public void ResetGameData()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = null;
        data.highScore = 0;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

}
