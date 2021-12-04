using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public int BestScore;

    public string CurrentPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerNameAndBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestScore;
    }

    public void SavePlayerNameAndBestScore()
    {
        SaveData saveData = new SaveData();
        saveData.PlayerName = PlayerName;
        saveData.BestScore = BestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerNameAndBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            PlayerName = saveData.PlayerName;
            BestScore = saveData.BestScore;
        }
        else
        {
            PlayerName = "Name";
            BestScore = 0;
        }
    }
}
