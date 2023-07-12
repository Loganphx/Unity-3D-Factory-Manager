using System;
using System.IO;
using System.Net;
using UnityEngine;

[Serializable]

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    
    public Color TeamColor { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);    
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadColor();
    }

    public class SaveData
    {
        public Color TeamColor;
    }
    
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            TeamColor = data.TeamColor;
        }
    }
}